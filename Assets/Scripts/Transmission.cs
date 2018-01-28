using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transmission : MonoBehaviour {	
	public Texture2D align_tex = null; // 
	public Texture2D enthusaism = null; // monochrome texture representing how excited **the people who support you** are
	// does a high enough enthusaism have benefits like spreading to other nearby people? TODO: test
	// is a blob of high enough enthusaism self-sustaining by mutual excitement?
	public Texture2D distribution = null; // monochrome texture representing what percentage of people in a given area support you. try and black this out.


	//Scene awakeScene;

	int width = 1920;
	int height = 1080;

	static int awake_calls = 0;

	void Awake() {
		if (awake_calls == 0) {
			awake_calls++;

				
			align_tex = new Texture2D(width, height);
			enthusaism = new Texture2D(width, height);
			distribution = new Texture2D(width, height);
			
			Color[] pixels = new Color[width * height];
			for (int i = 0; i < height * width; ++i) {
				pixels[i] = new Color(0,0,0,0);
			}
			enthusaism.SetPixels(pixels);
			enthusaism.Apply();
			distribution.SetPixels(pixels);
			distribution.Apply();

			
			float scale = 100.0f;
			// alignment (or rather, agreeability of candidate's position per district) uses a noise texture
			for (int r = 0; r < height; ++r) {
				for (int c = 0; c < width; ++c) {
					float x = c / (float)width * scale;
					float y = r / (float)height * scale;
					float sample = Mathf.PerlinNoise(x, y);

					pixels[r * width + c] = new Color(sample, sample, sample, 0);
				}
			}
			align_tex.SetPixels(pixels);
			align_tex.Apply();

			
			DontDestroyOnLoad(gameObject);
			//awakeScene = SceneManager.GetActiveScene();
			SceneManager.sceneLoaded += this.OnLoadCallback;
		}
		else {
			Destroy(gameObject);
		}
	}

	void TweetTick(Issue issue, float stance) {
		for (int r = 0; r < height; ++r) {
			for (int c = 0; c < width; ++c) {


				//pixels[r * width + c] = new Color(sample, sample, sample, 0);
			}
		}
	}
	

	void OnLoadCallback(Scene scene, LoadSceneMode sceneMode) {
		GameObject districts = GameObject.Find("District collection");
		if (districts) {
			foreach (District d in districts.GetComponentsInChildren<District>()) {
				d.SetAlignTex(align_tex);
			}
		}
		//gameObject.SetActive(scene.Equals(awakeScene));
	}
}
