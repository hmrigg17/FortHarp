using UnityEngine;
using System;
using System.Collections;

public class FadeInScript : Transition {

	// Public Variables
	public float fadeSpeed;			// The speed of the fade
	public GameObject fadeObject;	// The object that will be manipulated to achieve the fade

	// Private Variables
	private bool finishedTransition;

	// Unity Callbacks
	void Start () {
		// Initialize done to false
		finishedTransition = false;
	}

	void Update () {
		// Check to see if the transition has finished yet
		if (!finishedTransition) {
			Renderer renderer = fadeObject.GetComponent<Renderer>(); // Get the renderer for the fade object
			//Renderer playerRenderer = GameController.instance.player.GetComponent<Renderer>();
			Color newColor = renderer.material.color; // Get the color from the renderer
			newColor.a -= fadeSpeed; // Remove opacity from the color

			// If the opacity has reached its limit, or gone negative
			if (newColor.a <= 0) {
				newColor.a = 0; // Limit the opacity to the lower bound
				renderer.material.color = newColor; // Set the renderer to use its previous color with the new opacity

				// Check to see if there is a callback defined for the transition
				if (callback != null) {
					callback(); // If a callback exists, call it
				}

				finishedTransition = true; // Set the done flag to true so the fade stops
			} else {
				// Set the renderer to use its previous color with the new opacity
				renderer.material.color = newColor;
				//playerRenderer.enabled = true;
			}
		}
	}

	// Public Functions
	public override void Discard () {
		Destroy(gameObject); // Destroy this fade once the caller is done with it
	}
}
