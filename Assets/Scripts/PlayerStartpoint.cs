using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartpoint : MonoBehaviour {

	private PlayerController player;
	private CameraController camera;

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
