using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class switchScript : MonoBehaviour {

	public GameObject card, laser;
	public Light screen;
	public Text msg;
	bool triggered = false;

	public AudioSource sound;

	private void Update() {
		if (playerMovement.play.hasKey && triggered){
			if (Input.GetKey(KeyCode.E)){
				soundBase.sounds.granted.Play();
				laser.gameObject.SetActive(false);
				screen.color = Color.green;
			}
		}
	}

	private void OnTriggerEnter(Collider other) {
		// sound.Play();
		triggered = true;
		msg.enabled = true;
		if (!playerMovement.play.hasKey)
			msg.text = "Find the key card";
		else
			msg.text = "press E to open door";
	}

	private void OnTriggerExit(Collider other) {
			triggered = false;
			msg.enabled = false;
			msg.text = null;
	}

}
