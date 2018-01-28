using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

/**
 people are less likely to be high-enthusaism supporters of those who disagree with them a lot
 */
public enum Issue : uint {
	Environment = 0,
	Business,
	Guns,
	Race,
	Crime,
	Feminism,
	Domestic,

	NUM_ISSUES
}

public class Alignment : MonoBehaviour {
	[Range(-1.0f, 1.0f)] public float environment;
	[Range(-1.0f, 1.0f)] public float business;
	[Range(-1.0f, 1.0f)] public float guns;
	[Range(-1.0f, 1.0f)] public float race;
	[Range(-1.0f, 1.0f)] public float crime;
	[Range(-1.0f, 1.0f)] public float feminism;
	[Range(-1.0f, 1.0f)] public float domestic;

	static Alignment candidate;

	void Awake() {
		GameObject player = GameObject.Find("Player character");
		candidate = player.GetComponent<Alignment>();
	}

	/**
	 * \return a double in the range [0, 1] showing how responsive this alignment is to the player's policies
	 * uses euclidean distance, scaled to [0,1]
	 */
	static float max_distance = Mathf.Sqrt(4*(int)Issue.NUM_ISSUES);
	public float AgreesWithPlayerFactor() {
		return Mathf.Pow(
			
			1 - Mathf.Sqrt(
				Mathf.Pow(environment - candidate.environment, 2) +
				Mathf.Pow(business - candidate.business, 2) +
				Mathf.Pow(guns - candidate.guns, 2) +
				Mathf.Pow(race - candidate.race, 2) +
				Mathf.Pow(crime - candidate.crime, 2) +
				Mathf.Pow(feminism - candidate.feminism, 2) +
				Mathf.Pow(domestic - candidate.domestic, 2)
			) / (2*max_distance/3)
		
		, 2);
	}
}
