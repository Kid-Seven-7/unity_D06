using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour {

	public AudioSource denied;

	public audioManager sounds;

	private void Start() {
		sounds = this;
	}

	void playDeniedSound(){
		denied.Play();
	}

}
