using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;


public enum Issues : uint {
	Environment = 0,
	Business,
	Guns,

	NUM_ISSUES
}

public class Alignment : MonoBehaviour {
	double[] alignment; // all in the range [-1, 1]. roughly aligns to left-right leaning politics
	static Alignment candidate;

	void Awake() {
		alignment = new double[(uint)Issues.NUM_ISSUES];
		GameObject player = GameObject.Find("PlayerCharacter");
		candidate = player.GetComponent<Alignment>();
	}

	// TODO: expand as issue count goes up
	void SetAll(double environment, double business, double guns) {
	}

	void Set(Issues which, double stance) {
		// NUM_ISSUES only exists as a convenience; not a stance in itself
		Assert.IsFalse(which == Issues.NUM_ISSUES);
	}

	void Offset(Issues which, double delta) {
		
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
