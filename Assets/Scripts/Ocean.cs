using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ocean : MonoBehaviour {
	[SerializeField] private GameObject flag;
	[SerializeField] private GameObject details;
	TextMesh displayName;
	SpriteRenderer displayIcon;
	SmartTextMesh displayDesc;

	void Start() {
		displayName = details.GetComponentInChildren<TextMesh>();
		displayIcon = details.GetComponentInChildren<SpriteRenderer>();
		displayDesc = details.GetComponentInChildren<SmartTextMesh>();
	}

	void OnMouseOver() {
		flag.SetActive(false);
		details.SetActive(false);
	}

	void OnMouseExit() {
		flag.SetActive(true);
		details.SetActive(true);
	}
}
