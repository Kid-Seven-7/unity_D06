using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class playerMovement : MonoBehaviour {

	public Rigidbody player;
	public Slider slider;
	public Image fill;
	public Text msg;
	public static playerMovement play;
	public bool hasKey, hasFile, inSight;
	float speed, time;
	// public ;

	public float stealth;

	// Use this for initialization
	void Start () {
		play = this;
		speed = 0.2f;
		hasKey = false;
		stealth = 0;
		time = 0;
		inSight = false;
	}
	
	private void Update() {

		if (stealth < .5){
			if (!soundBase.sounds.gameMusic.isPlaying)
				soundBase.sounds.gameMusic.Play();
		}
		if (stealth > .5)
		{
			soundBase.sounds.gameMusic.Stop();
			if (!soundBase.sounds.tense.isPlaying)
				soundBase.sounds.tense.Play();
		}

		time += Time.deltaTime;

		if (inSight)
			stealth += 0.002f;
		if (!inSight)
			stealth -= 0.0001f;

		// if (Mathf.RoundToInt(time) % 15 == 0)
			// stealth -= 0.0015f;
		if (stealth > 0.5f && stealth < 0.75f)
			msg.text = "Look for cover";
		if (stealth > 0.999f){
			msg.text = "You were detected Restarting simulation";
			StartCoroutine(restart());
			
		}

	}

	// Update is called once per frame
	void FixedUpdate () {
		slider.value = stealth;
		player.transform.Rotate(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
		player.transform.rotation = Quaternion.Euler(player.transform.rotation.eulerAngles.x, player.transform.rotation.eulerAngles.y, 0f);

		if (Input.GetKey(KeyCode.W))
			player.AddForce(player.transform.forward * speed, ForceMode.VelocityChange);
		if (Input.GetKey(KeyCode.S))
			player.AddForce(-player.transform.forward * speed, ForceMode.VelocityChange);
		if (Input.GetKey(KeyCode.D))
			player.AddForce(player.transform.right * speed, ForceMode.VelocityChange);
		if (Input.GetKey(KeyCode.A))
			player.AddForce(-player.transform.right * speed, ForceMode.VelocityChange);
	}

	IEnumerator restart()
	{
		if (!soundBase.sounds.endGame.isPlaying)
			soundBase.sounds.endGame.Play();
		yield return new WaitForSeconds(5);
		SceneManager.LoadScene("level");
	}
}
