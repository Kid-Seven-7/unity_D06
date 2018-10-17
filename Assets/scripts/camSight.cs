using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camSight : MonoBehaviour {

	private void OnTriggerEnter(Collider other) {
		playerMovement.play.inSight = true;
	}

	private void OnTriggerExit(Collider other)
	{
		playerMovement.play.inSight = false;
	}
}
