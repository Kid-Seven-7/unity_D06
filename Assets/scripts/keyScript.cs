using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class keyScript : MonoBehaviour {

	public GameObject keyCard;
	public Transform key;
	public Text msg;

	public bool triggered = false;

	// Update is called once per frame
	void Update () {
		key.transform.Rotate(Vector3.up);
		if (triggered && Input.GetKeyDown("e")){
			soundBase.sounds.pickUpKey.Play();
			playerMovement.play.hasKey = true;
			keyCard.SetActive(false);
		}
	}

private void OnTriggerEnter(Collider other){
		triggered = true;
		msg.enabled = true;
		msg.text = "press E to pick up key card";
	}

	private void OnTriggerExit(Collider other){
		triggered = false;
		msg.enabled = false;
		msg.text = null;
	}
}
