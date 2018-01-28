using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transmission : MonoBehaviour {	
	Texture2D align_tex = null; // 
	public Texture2D enthusaism; // monochrome texture representing how excited **the people who support you** are
	// does a high enough enthusaism have benefits like spreading to other nearby people? TODO: test
	// is a blob of high enough enthusaism self-sustaining by mutual excitement?
	public Texture2D distribution; // monochrome texture representing what percentage of people in a given area support you. try and black this out.

	// only used to reference texture. don't actually care about the contents
	Texture2D area;

	void Awake() {
		area = gameObject.GetComponentInChildren<SpriteRenderer>().sprite.texture;

		align_tex = new Texture2D(area.width, area.height);
		enthusaism = new Texture2D(area.width, area.height);
		distribution = new Texture2D(area.width, area.height);
		
		Color[] pixels = new Color[area.width * area.height];
		for (int i = 0; i < area.height * area.width; ++i) {
			pixels[i] = new Color(0,0,0, 0);
		}
		enthusaism.SetPixels(pixels);
		enthusaism.Apply();
		distribution.SetPixels(pixels);
		distribution.Apply();

		
		float scale = 100.0f;
		// alignment (or rather, agreeability of candidate's position) uses a noise texture
		for (int r = 0; r < area.height; ++r) {
			for (int c = 0; c < area.width; ++c) {
				float x = c / (float)area.width * scale;
				float y = r / (float)area.height * scale;
				float sample = Mathf.PerlinNoise(x, y);

				pixels[r * area.width + c] = new Color(sample, sample, sample, 0);
			}
		}
		align_tex.SetPixels(pixels);
		align_tex.Apply();

		foreach (District d in gameObject.GetComponentsInChildren<District>()) {
			d.SetAlignTex(align_tex);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
