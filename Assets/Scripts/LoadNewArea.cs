using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour {
	// used tutorial: [https://www.youtube.com/watch?v=x9lguwc0Pyk&list=PLiyfvmtjWC_X6e0EYLPczO9tNCkm2dzkm&index=9]

	public string levelToLoad;

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {}

	void OnTriggerEnter2D (Collider2D other) {

		ScreenFader sf = GameObject.FindWithTag("Fader").GetComponent<ScreenFader>();

		if (other.gameObject.name == "Player") {
			sf.FadeToBlack (); // from this tutorial: [https://www.youtube.com/watch?v=2XNP6Qf2gDU]
			SceneManager.LoadScene (levelToLoad);
			sf = GameObject.FindWithTag("Fader").GetComponent<ScreenFader>();
			sf.FadeToClear (); // from this tutorial: [https://www.youtube.com/watch?v=2XNP6Qf2gDU]
		}
	}
}
