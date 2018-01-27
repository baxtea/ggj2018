using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// stores the initial data of the district as well as updating the preferences each tick
// when ticks happen, is the sustain a gaussian falloff or just a district-wide event? probably district-wide
public class District : MonoBehaviour {
	//
	// these fields are to be considered immutable as soon as Start() is called
	//
	[SerializeField] private SpriteRenderer rend;
	[SerializeField] private TextMesh displayName;
	public static uint NUM_DISTRICTS = 0; // incremented when each district is created

	public string districtName;
	public string description; // a quick description of the district
	public Texture2D icon = null; // to display in a popup window on hover
	Texture2D area = null; // a texture defining the location of this district through what's alpha and what's not
	public double sustain = 0.9; //  (0,1) exponential decay factor. number is how much enthusaism is kept through each tick
	
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
		NUM_DISTRICTS++;
	}

	// Use this for initialization
	// something is still wonky with the scale I think
	void Start () {
		composite = new Texture2D(area.width, area.height);

		Color[] area_pix = area.GetPixels();
		Color[] align_pix = align_tex.GetPixels();
		for (int r = 0; r < area.height; ++r) {
			for (int c = 0; c < area.width; ++c) {

				// alter the noise in the localized area to offset by how much the player agrees with local politics
				float alpha = area_pix[r * area.width + c].a;
				if (alpha > 0) {
					float sample = align_pix[r * area.width + c].r; // noise as generated in Transmission.Awake
					sample = alignment.AgreesWithPlayerFactor()*5/6 + sample/6;

					align_pix[r * area.width + c] = new Color(sample, sample, sample, alpha);
				}
			}
		}
		align_tex.SetPixels(align_pix);
		align_tex.Apply();


		// DEBUG: eventually will use composite texture here
		rend.sprite = Sprite.Create(align_tex, new Rect(0, 0, area.width, area.height), new Vector2(0.5f, 0.5f), 100.0f);

		UpdateComposite();
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
	/*void Rally (int x, int y) {

		Color[] align_pix = align_tex.GetPixels();
		Color[] dist_pix = distribution.GetPixels();

		System.Random rand = new System.Random();
		for (int r = x-256; r < area.height && r < y+256; ++r) {
			for (int c = y-256; c < area.width && c < y+256; ++c) {
				// send out a wave altering distribution as it relates to alignment
				// was planning to use inverse square falloff, but i think cosine makes more sense. cheap approximation of gaussian 
				dist_pix[r * area.width + c] += align_pix[r * area.width + c] * NextFloat(rand);// * 1/Mathf.Pow(, 2);

				// now send out a 
			}
		}
	}*/

	void UpdateComposite() {

	}

	void OnMouseOver() {
		displayName.text = districtName;
	}
}
