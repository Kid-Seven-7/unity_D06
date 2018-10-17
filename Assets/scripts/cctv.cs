using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cctv : MonoBehaviour {

	public GameObject fp, player;

	Vector3 hori = new Vector3(0.1f, 0.0f, 0.1f);
	Vector3 vert = new Vector3(0.0f,0.1f,0.1f);

	// Update is called once per frame
	void Update () {
		RaycastHit ray1;

		Physics.Raycast(fp.transform.position, fp.transform.TransformDirection(Vector3.forward) * 1000, out ray1, 100.0f);

		if (ray1.collider == player.gameObject.GetComponent<Collider>())
			Debug.Log("in sight");

		GameObject myLine = new GameObject();
		myLine.transform.position = fp.transform.position;
		myLine.AddComponent<LineRenderer>();
		LineRenderer lr = myLine.GetComponent<LineRenderer>();
		lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
		lr.startColor = Color.red;
		lr.endColor = Color.black;
		lr.startWidth = 0.01f;
		lr.SetPosition(0, fp.transform.position);
		lr.SetPosition(1, ray1.point);
		// GameObject.Destroy(myLine, 2f);
		Destroy(myLine);
	}
}
