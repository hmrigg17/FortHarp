using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerLoader : MonoBehaviour {
	// [https://unity3d.com/learn/tutorials/projects/2d-roguelike-tutorial/writing-game-manager?playlist=17150]


	public GameObject gameManager;

	// Use this for initialization
	void Awake () {
		Debug.Log ("The Manager Loader is awake.");
		if (GameManager.instance == null)
			Instantiate (gameManager);
	}

	// Update is called once per frame
	void Update () {

	}
}