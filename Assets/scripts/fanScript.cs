using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class fanScript : MonoBehaviour {

	public  Text msg;
	public  GameObject parts, player;

	public bool triggered, on = false;
	public ParticleSystem ps;

	private void Update() {
		if (Vector3.Distance(parts.transform.position,
		player.transform.position) < 5){
			if (Input.GetKey(KeyCode.E))
				on = true;

			if (on)
				parts.SetActive(true);
		}
	}
	private void OnTriggerEnter(Collider other) {
		msg.enabled = true;
		msg.text = "Press E to activate";
	}

	private void OnTriggerExit(Collider other) {
		msg.enabled = false;
		msg.text = null;
	}
}
