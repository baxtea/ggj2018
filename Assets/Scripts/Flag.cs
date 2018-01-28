using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [RequireComponent(typeof(SpriteRenderer))]
public class Flag : MonoBehaviour {
	Sprite texture;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		/*Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 25)) {
			float oldZ = transform.position.z;
			transform.position.Set(hit.point.x, hit.point.y, oldZ);
		}*/

		Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		//Camera.main.ScreenToViewportPoint(Input.mousePosition);
		transform.position = new Vector3(mouse.x-0.01f, mouse.y-0.01f, transform.position.z);
	}
}
