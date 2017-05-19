using UnityEngine;
using System;
using System.Collections;

public class FadeOutScript : Transition {

	// Public Variables
	public float fadeSpeed;			// The speed of the fade
	public GameObject fadeObject;	// The object that will be manipulated to achieve the fade

	// Private Variables
	private bool finishedTransition; // Whether or not the transition has completed

	
	// Unity Callbacks
	void Start () {
		// Initialize done to false
		finishedTransition = false;
		//Renderer playerRenderer = GameController.instance.player.GetComponent<Renderer> ();
		//playerRenderer.enabled = false;
	}

	void Update () {
		// Check to see if the transition has finished yet
		if (!finishedTransition) {
			Renderer renderer = fadeObject.GetComponent<Renderer>(); // Get the renderer for the fade object
			Color newColor = renderer.material.color; // Get the color from the renderer
			newColor.a += fadeSpeed; // Add opacity from the color

			// If the opacity has reached its limit, or gone negative
			if (newColor.a >= 1) {
				newColor.a = 1; // Limit the opacity to the lower bound
				renderer.material.color = newColor; // Set the renderer to use its previous color with the new opacity
				// Check to see if there is a callback defined for the transition
				if (callback != null) {
					callback(); // If a callback exists, call it
				}
					
				finishedTransition = true; // Set the done flag to true so the fade stops
			} else {
				renderer.material.color = newColor; // Set the renderer to use its previous color with the new opacity
			}
		}
	}


	// Public Functions
	public override void Discard () {
		Destroy(gameObject); // Destroy this fade once the caller is done with it
	}
}
