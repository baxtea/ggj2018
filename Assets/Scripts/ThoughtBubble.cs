using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThoughtBubble : MonoBehaviour {
	public int which;
	public Tweeting controller;

	void OnMouseDown() {
		Debug.Log(gameObject.name);
		controller.ChoiceMade(which);
	}
}
