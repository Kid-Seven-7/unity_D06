using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class papersScript : MonoBehaviour {

	public Text msg;

	public GameObject files, player;

	public bool inRange = false;

	private void Start() {
		inRange = false;
	}

	private void Update() {

		if (Vector3.Distance(files.transform.position, player.transform.position) < 10f)
			inRange = true;
		if (Vector3.Distance(files.transform.position, player.transform.position) > 10f)
			inRange = false;
		if (Input.GetKey(KeyCode.E) && inRange){
			playerMovement.play.hasFile = true;
			files.SetActive(false);
			msg.enabled = true;
			msg.text = "Congratulations- you won";
			StartCoroutine(won());
		}

	}

	private void OnTriggerEnter(Collider other) {
		msg.enabled = true;
		msg.text = "Press E to pick up file";
	}

	private void OnTriggerExit(Collider other) {
		msg.enabled = false;
		msg.text = null;
	}

	IEnumerator won()
	{
		msg.text += "You win - restarting simulation";
		playerMovement.play.stealth = -100f;
		yield return new WaitForSeconds(5);
		SceneManager.LoadScene("level");
	}
}
