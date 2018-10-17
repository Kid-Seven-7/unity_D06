using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slidingDoor : MonoBehaviour {

	public Rigidbody door1, door2;
	public GameObject door1obj, door2obj;
	Vector3 door1Pos, door2Pos;

	bool open;

	private void Start() {
		open = false;
		door1Pos = door1.transform.position;
		door2Pos = door2.transform.position;
	}

	private void Update() {
		if (open){
			door1.transform.position = new Vector3(door1Pos.x + 0.06f, door1Pos.y, door1Pos.z);
			door2.transform.position = new Vector3(door2Pos.x - 0.06f, door2Pos.y, door2Pos.z);
		}
	}

	private void OnTriggerEnter(Collider other) {
		Debug.Log("trigger");
		door1.constraints = RigidbodyConstraints.None;
		door2.constraints = RigidbodyConstraints.None;
		door1obj.transform.position = new Vector3(door1Pos.x - 0.06f, door1Pos.y, door1Pos.z);
		door2obj.transform.position = new Vector3(door2Pos.x + 0.06f, door2Pos.y, door2Pos.z);
		open = true;
		door1.constraints = RigidbodyConstraints.FreezeAll;
		door2.constraints = RigidbodyConstraints.FreezeAll;
	}
}
