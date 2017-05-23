using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {
	public GameObject PauseUI;

	private bool paused = false;

	void Start (){
		PauseUI.SetActive (false);
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Escape)) {
			paused = !paused;
		}

		if (paused) {
			PauseUI.SetActive (true);
			Time.timeScale = 0;
		} 
		else {
			PauseUI.SetActive (false);
			Time.timeScale = 1;
		}
	}

}



