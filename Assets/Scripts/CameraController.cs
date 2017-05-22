using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	// [https://www.youtube.com/watch?v=J6BQ4Fcy4cc&index=5&list=PLiyfvmtjWC_X6e0EYLPczO9tNCkm2dzkm]

	/* This code for some reason is not working the way that it should, so it 
	 * doesn't actually appear anywhere in the game. I've left it for future use,
	 * assuming I can figure out what's wrong, and used a work-around (making the
	 * camera a child of the player). 												*/

	public GameObject followTarget;
	//public float moveSpeed;

	public Vector3 offset;
	//private Vector3 targetPosition;
	private static bool cameraExists;

	// Use this for initialization
	void Start () {
		if (!cameraExists) {
			cameraExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} else {
			Destroy (gameObject);
		}

		offset = this.transform.position - followTarget.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		//targetPosition = new Vector3 (followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
		transform.position = followTarget.transform.position + offset; 
	}
}
