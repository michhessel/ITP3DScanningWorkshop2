using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiatePoop : MonoBehaviour {

	public GameObject poop;
	public float myTime = 2f;

	// Update is called once per frame
	void Update () {
		spawnPoop ();
	}


	void spawnPoop(){
		myTime -= Time.deltaTime;
		if (myTime <= 0f) {
			//instantiate (what, where, rotation):
			Vector3 position = new Vector3 ((Random.Range (-30f, 30f)), (Random.Range (10f, 15f)), (Random.Range (-30f, 30f)));
			Instantiate (poop, position, Quaternion.Euler (0, 0, 0));
			myTime = 2f;
		}
	}



}
