using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

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


	Capital capital;
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


	public void SetAlignTex(Texture2D texture) {
		align_tex = texture;
	}

	void Awake() {
		area = rend.sprite.texture;
		capital = gameObject.GetComponentInChildren<Capital>();
	}

	// Use this for initialization
	void Start () {
		Transmission transmission = GameObject.Find("Persistent").GetComponent<Transmission>();
		distribution = transmission.distribution;
		enthusaism = transmission.enthusaism;

		if (NUM_DISTRICTS < 7) {
			Color[] area_pix = area.GetPixels();
			Color[] align_pix = align_tex.GetPixels();


			// districts never extend more than 400 pixels away from their capital
			int dist = 400;
			int x = (int)capital.texture_loc.x;
			int y = (int)capital.texture_loc.y;
			for (int r = Math.Max(y-dist, 0); r < area.height && r < y+dist; ++r) {
				for (int c = Math.Max(x-dist, 0); c < area.width && c < x+dist; ++c) {

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
		}

		UpdateComposite();
		NUM_DISTRICTS++;
		if (NUM_DISTRICTS % 7 == 0) {
			GameObject.Find("Debug").GetComponent<SpriteRenderer>().sprite = Sprite.Create(align_tex, new Rect(0, 0, area.width, area.height), new Vector2(0.5f, 0.5f), 100.0f);
		}
	}

	/**
	 * \return a float in the range [0, 1]
	 * don't judge me god
	 */
	static float NextFloat(System.Random random)
	{
		var buffer = new byte[4];
		random.NextBytes(buffer);
		return System.BitConverter.ToSingle(buffer,0) % 1;
	}

	float distance(int x1, int x2, int y1, int y2) {
		return Mathf.Sqrt((x1-x2)*(x1-x2) + (y1-y2)*(y1-y2));
	}
	
	// ideally i can animate like a "pulse" but i'm not very optimistic
	void Rally (int x, int y) {

		Color[] align_pix = align_tex.GetPixels();
		Color[] dist_pix = distribution.GetPixels();
		Color[] enth_pix = enthusaism.GetPixels();

		Tick(align_pix, dist_pix, enth_pix);

		int dist = 400;
		for (int r = Math.Max(y-dist, 0); r < area.height && r < y+dist; ++r) {
			for (int c = Math.Max(x-dist, 0); c < area.width && c < x+dist; ++c) {
				// send out a wave altering distribution as it relates to alignment
				
				float d = distance(x, c, y, r);
				// this is what i want excitement to do
				// people nearby get excited no matter what, but a little moreso if they agree with a lot of your politics
				// careful, excited people who disagree with you are bad
				float alpha = align_pix[r*area.width+c].a;
				float sample = enth_pix[r*area.width+c].r + (100/d) * align_pix[r*area.width+c].r;
				enth_pix[r*area.width+c] = new Color(sample, sample, sample, alpha);

				// probably what i want distribution to do
				// inverse square falloff, scaled with how much they agree with your politics
				sample = dist_pix[r*area.width+c].r + align_pix[r*area.width+c].r * Mathf.Clamp01(2/Mathf.Pow(d/25, 2));
				dist_pix[r*area.width+c] = new Color(sample, sample, sample, alpha);

				// alter alignment of people really nearby (you convinced these people, i guess)
				sample = align_pix[r*area.width + c].r + 1/d;
				align_pix[r*area.width+c] = new Color(sample, sample, sample, alpha);
			}
		}
		enthusaism.SetPixels(enth_pix);
		enthusaism.Apply();
		distribution.SetPixels(dist_pix);
		distribution.Apply();
		align_tex.SetPixels(align_pix);
		align_tex.Apply();
	}

	void Tick() {

	}

	void Tick(Color[] alignment, Color[] distribution, Color[] enthusaism) {

	}

	void UpdateComposite() {

	}

	void OnMouseOver() {
		flag.transform.position = capital.transform.position;

		displayName.text = districtName;
		displayIcon.sprite = icon;
		displayDesc.UnwrappedText = description;
		displayDesc.NeedsLayout = true;
	}

	void OnMouseDown() {
		Rally((int)capital.texture_loc.x, (int)capital.texture_loc.y);
        StartCoroutine(ToTweet());
    }
    IEnumerator ToTweet()
    {
        Debug.Log("Going to Tweets");
        yield return new WaitForSeconds(1);//Pause before showing options    
		transform.parent.gameObject.SetActive(false);
        SceneManager.LoadScene("Tweeting");
        yield return null;
    }
}
