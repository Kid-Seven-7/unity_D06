using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundBase : MonoBehaviour {

	static public soundBase sounds;

	public AudioSource gameMusic,
	denied, footsteps, pickUpKey,
	tense, granted, endGame;

	// Use this for initialization
	void Start () {
		sounds = this;
		gameMusic.volume = .5f;
	}
}
