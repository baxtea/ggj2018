using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// stores the initial data of the district as well as updating the preferences each tick
// when ticks happen, is the sustain a gaussian falloff or just a district-wide event? probably district-wide
[RequireComponent(typeof(GameObject))]
public class District : MonoBehaviour {
	//
	// these fields are to be considered immutable as soon as Start() is called
	//
	[SerializeField] private SpriteRenderer rend;
	[SerializeField] private TextMesh displayName;
	[SerializeField] private SpriteRenderer displayIcon;
	[SerializeField] private SmartTextMesh displayDesc;
	static uint NUM_DISTRICTS = 0; // incremented when each district is created

	public string districtName;
	public string description; // a quick description of the district
	public Sprite icon = null; // to display in a popup window on hover
	Texture2D area = null; // a texture defining the location of this district through what's alpha and what's not
	public double sustain = 0.9; //  (0,1) exponential decay factor. number is how much enthusaism is kept through each tick


	Vector3 capital_loc;
	public GameObject flag;
	
	// not sure if this field is mutable or not
	public Alignment alignment; // the average district citizen's stance for each issue

	//
	// these fields can change during runtime
	//
	Texture2D align_tex = null; // 
	Texture2D enthusaism; // monochrome texture representing how excited **the people who support you** are
	// does a high enough enthusaism have benefits like spreading to other nearby people? TODO: test
	// is a blob of high enough enthusaism self-sustaining by mutual excitement?
	Texture2D distribution; // monochrome texture representing what percentage of people in a given area support you. try and black this out.


	//
	// what the player actually sees
	//
	Texture2D composite;

	public void SetAlignTex(Texture2D texture) {
		align_tex = texture;
	}

	void Awake() {
		area = rend.sprite.texture;
		capital_loc = gameObject.GetComponentInChildren<Capital>().transform.position;
		//flag = GameObject.Find("flag");
	}

	// Use this for initialization
	// something is still wonky with the scale I think
	void Start () {
		distribution = GetComponentInParent<Transmission>().distribution;
		enthusaism = GetComponentInParent<Transmission>().enthusaism;

		//composite = new Texture2D(area.width, area.height);

		Color[] area_pix = area.GetPixels();
		Color[] align_pix = align_tex.GetPixels();

		for (int r = 0; r < area.height; ++r) {
			for (int c = 0; c < area.width; ++c) {

				// alter the noise in the localized area to offset by how much the player agrees with local politics
				float alpha = area_pix[r * area.width + c].a;
				if (alpha > 0) {
					float sample = align_pix[r * area.width + c].r; // noise as generated in Transmission.Awake
					sample = alignment.AgreesWithPlayerFactor()*4/5 + sample/5;

					align_pix[r * area.width + c] = new Color(sample, sample, sample, alpha);
				}
			}
		}
		align_tex.SetPixels(align_pix);
		align_tex.Apply();

		UpdateComposite();
		NUM_DISTRICTS++;
		if (NUM_DISTRICTS == 7) {
			GameObject.Find("Debug").GetComponent<SpriteRenderer>().sprite = Sprite.Create(align_tex, new Rect(0, 0, area.width, area.height), new Vector2(0.5f, 0.5f), 100.0f);
		}
	}

	/**
	 * \return 
	 */
	static float NextFloat(System.Random random)
	{
		var buffer = new byte[4];
		random.NextBytes(buffer);
		return System.BitConverter.ToSingle(buffer,0);
	}
	
	// ideally i can show like a "pulse" but i'm not very optimistic
	void Rally (int x, int y) {

		Color[] align_pix = align_tex.GetPixels();
		Color[] dist_pix = distribution.GetPixels();


		int dist = 25;
		System.Random rand = new System.Random();
		for (int r = Math.Max(y-dist, 0); r < area.height && r < y+dist; ++r) {
			for (int c = Math.Max(x-dist, 0); c < area.width && c < x+dist; ++c) {
				// send out a wave altering distribution as it relates to alignment
				// was planning to use inverse square falloff, but i think cosine makes more sense. cheap approximation of gaussian 
				
				align_pix[r * area.width + c] = new Color(1,1,1,1);
				//dist_pix[r * area.width + c] += align_pix[r * area.width + c] * NextFloat(rand);// * 1/Mathf.Pow(, 2);

				// now send out a 
			}
		}
		align_tex.SetPixels(align_pix);
		align_tex.Apply();
	}

	void UpdateComposite() {

	}

	void OnMouseOver() {
		flag.transform.position = capital_loc;

		displayName.text = districtName;
		displayIcon.sprite = icon;
		displayDesc.UnwrappedText = description;
		displayDesc.NeedsLayout = true;
	}
}
