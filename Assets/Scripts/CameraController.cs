using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

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
