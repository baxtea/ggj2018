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
	public static uint NUM_DISTRICTS = 0; // incremented when each district is created

	public string districtName;
	public string description; // a quick description of the district
	public Texture2D icon = null; // to display in a popup window on hover
	Texture2D area = null; // a texture defining the location of this district through what's alpha and what's not
	Texture2D align_tex = null; // 
	public double sustain = 0.9; //  (0,1) exponential decay factor. number is how much enthusaism is kept through each tick
	
	// not sure if this field is mutable or not
	public Alignment alignment; // the average district citizen's stance for each issue

	//
	// these fields can change during runtime
	//

	Texture2D enthusaism; // monochrome texture representing how excited **the people who support you** are
	// does a high enough enthusaism have benefits like spreading to other nearby people? TODO: test
	// is a blob of high enough enthusaism self-sustaining by mutual excitement?
	Texture2D distribution; // monochrome texture representing what percentage of people in a given area support you. try and black this out.

	//
	// used to edit the texture
	//
	Color[] pixels; // used to edit the textures manually. pitch of area.width
	Texture2D composite;

	void Awake() {
		area = rend.sprite.texture;
		NUM_DISTRICTS++;
	}

	// Use this for initialization
	// something is still wonky with the scale I think
	void Start () {

		composite = new Texture2D(area.width, area.height);
		// initialize each district texture with some noise
		align_tex = new Texture2D(area.width, area.height);
		enthusaism = new Texture2D(area.width, area.height);
		distribution = new Texture2D(area.width, area.height);
		float scale = 40.0f;

		Color[] area_pixels = area.GetPixels();
		pixels = new Color[area.width * area.height];

		// enthusaism and distribution start at 0 across the board
		for (int i = 0; i < area.height * area.width; ++i) {
			pixels[i] = new Color(0,0,0);
		}
		enthusaism.SetPixels(pixels);
		enthusaism.Apply();
		distribution.SetPixels(pixels);
		distribution.Apply();

		// alignment (or rather, agreeability of candidate's position) uses a noise texture
		for (int r = 0; r < area.height; ++r) {
			for (int c = 0; c < area.width; ++c) {
				float x = c / (float)area.width * scale;
				float y = r / (float)area.height * scale;
				float sample = Mathf.PerlinNoise(x, y);

				// restrict noise to localized area and offset by how much the player agrees
				sample = alignment.AgreesWithPlayerFactor()*5/6 + sample/6;
				sample *= area_pixels[r * area.width + c].a;

				pixels[r * area.width + c] = new Color(sample, sample, sample, area_pixels[r * area.width + c].a);
			}
		}
		align_tex.SetPixels(pixels);
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
	void Rally (int x, int y) {

		Color[] align_pix = align_tex.GetPixels();
		Color[] dist_pix = distribution.GetPixels();

		System.Random rand = new System.Random();
		for (int r = x-256; r < area.height && r < y+256; ++r) {
			for (int c = y-256; c < area.width && c < y+256; ++c) {
				// send out a wave altering distribution as it relates to alignment
				dist_pix[r * area.width + c] += align_pix[r * area.width + c] * NextFloat(rand);// * 1/Mathf.Pow(, 2);

				// now send out a 
			}
		}
	}

	void UpdateComposite() {

	}
}
