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

	[SerializeField] public string district_name;
	[SerializeField] public string description; // a quick description of the district
	[SerializeField] public Texture2D icon = null; // to display in a popup window on hover
	public Texture2D area = null; // a monochrome texture where the 
	[SerializeField] public double flexibility = 0.5; // [0,1] how likely any person is to be convinced by talking points very different to their own
	[SerializeField] public double sustain = 0.9; //  (0,1) exponential decay factor. number is how much enthusaism is kept through each tick
	// not sure if this field is mutable or not
	[SerializeField] public double[] alignment; // [-1,1] has an stance (very roughly left-right) for each issue. must be allocated to at least IssueNames.NUM_ISSUES length

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

	[SerializeField] private int pix_width = 256, pix_height = 256;
	private int tex_width, tex_height;
	Color[] pixels; // used to edit the textures manually. pitch of tex_width.
	Texture2D composite;

	void Awake() {
		NUM_DISTRICTS++;
	}

	// Use this for initialization
	void Start () {
		composite = new Texture2D(pix_width, pix_height);
		// initialize each district texture with some noise
		enthusaism = new Texture2D(pix_width, pix_height);
		distribution = new Texture2D(pix_width, pix_height);
		tex_width = enthusaism.width;
		tex_height = enthusaism.height;
		float scale = 1.0f;

		pixels = new Color[tex_width * tex_height];
		for (int r = 0; r < tex_height; ++r) {
			for (int c = 0; c < tex_width; ++c) {
				float x = c / tex_width * scale;
				float y = r / tex_height * scale;
				float sample = Mathf.PerlinNoise(x, y);

				// TODO: offset this noise by how well the district's base preferences align with the player's

				pixels[r * tex_width + c] = new Color(sample, sample, sample);
			}
		}
		enthusaism.SetPixels(pixels);
		enthusaism.Apply();


		// DEBUG: eventually will use composite texture here
		rend.sprite = Sprite.Create(enthusaism, new Rect(0, 0, tex_width, tex_height), new Vector2(0.5f, 0.5f), 100.0f);

		// and then offset that noise by how well the district's base preferences align with your own
		

		UpdateComposite();
	}
	
	// Tick is called whenever... plane lands? plane takes off? after a rally?
	void Tick () {
		// CPU-side texture editing because I'm a scrub
		for (int r = 0; r < tex_height; ++r) {
			for (int c = 0; c < tex_width; ++c) {

			}
		}
	}

	void UpdateComposite() {

	}
}
