using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartpoint : MonoBehaviour {
	// [https://www.youtube.com/watch?v=tevpiu8CW6I&list=PLiyfvmtjWC_X6e0EYLPczO9tNCkm2dzkm&index=10]

	private PlayerController player;
	//private CameraController camera;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
		//camera = FindObjectOfType<CameraController> ();

		player.transform.position = this.transform.position;
		//camera.transform.position = this.transform.position + camera.offset;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
