using UnityEngine;
using System;
using System.Collections;

public class FadeOutScript : Transition {

	// Public Variables
	// The speed of the fade
	public float fadeSpeed;

	// The object that will be manipulated to achieve the fade
	public GameObject fadeObject;


	// Private Variables
	// Whether or not the transition has completed
	private bool done;

	
	// Unity Callbacks
	void Start () {
		// Initialize done to false
		done = false;
	}

	void Update () {
		// Check to see if the transition has finished yet
		if (!done) {
			// Get the renderer for the fade object
			Renderer renderer = fadeObject.GetComponent<Renderer>();

			// Get the color from the renderer
			Color newColor = renderer.material.color;

			// Remove opacity from the color
			newColor.a += fadeSpeed;

			// If the opacity has reached its limit, or gone negative
			if (newColor.a >= 1) {
				// Limit the opacity to the lower bound
				newColor.a = 1;

				// Set the renderer to use its previous color with the new opacity
				renderer.material.color = newColor;

				// Check to see if there is a callback defined for the transition
				if (callback != null) {
					// If a callback exists, call it
					callback();
				}

				// Set the done flag to true so the fade stops
				done = true;
			} else {
				// Set the renderer to use its previous color with the new opacity
				renderer.material.color = newColor;
			}
		}
	}


	// Public Functions
	public override void Discard () {
		// Destroy this fade once the caller is done with it
		Destroy(gameObject);
	}
}
