using UnityEngine;
using System.Collections;

public class MapTriggerController : MonoBehaviour {

	// Public Variables
	// The map that will be switched to when this trigger is hit
	public GameObject newMap;

	// The player's position on the new map
	public Vector2 startPosition;

	// The transition that will be used before the new map is loaded
	public GameObject preTransition;

	// The transition that will be used after the new map is loaded
	public GameObject postTransition;


	// Private Variables
	// The instance of the transition that will be used before the new map is loaded
	private GameObject preTransitionInstance;

	// The instance of the transition that will be used after the new map is loaded
	private GameObject postTransitionInstance;

	// The reference to the script used by the pre transition
	private Transition preScript;

	// The reference to the script used by the post transition
	private Transition postScript;


	// Unity Callbacks
	void OnTriggerEnter2D (Collider2D other) {
		// If it is the player that hit this trigger
		if (other.gameObject.tag == "Player") {
			// Remove control from the player
			GameController.playerHasControl = false;

			// Stop the player from moving
			GameController.ResetPlayerVelocity();

			// If a pre transition has been defined
			if (preTransition != null) {
				// Make a new instance of the transition
				preTransitionInstance = Instantiate(preTransition, transform.position, Quaternion.identity) as GameObject;

				// Get the transition script component from the transition
				preScript = preTransitionInstance.GetComponent<Transition>();

				// Set the callback of the transition to the function AfterPreTransition
				preScript.callback = AfterPreTransition;
			} else {
				// If no transition is defined, then call AfterPreTransition
				AfterPreTransition();
			}
		}
	}


	// Public Functions
	public void AfterPreTransition () {
		// Tell the game controller to swap to the new map
		GameController.SwapMap(newMap);

		// Set the player's position to the new position on the map
		GameController.SetPlayerPosition(startPosition);

		// If there was a pre transition
		if (preScript != null) {
			// Discard the transition
			preScript.Discard();
		}

		// If a post transition has been defined
		if (postTransition != null) {
			// Make a new instances of the transition
			postTransitionInstance = Instantiate(postTransition, transform.position, Quaternion.identity) as GameObject;

			// Get the transition script component of the transition
			postScript = postTransitionInstance.GetComponent<Transition>();

			// Set the callback of the transition to the function AfterPostTransition
			postScript.callback = AfterPostTransition;
		} else {
			// If no transition is defined, then call AfterPostTransition
			AfterPostTransition();
		}
	}

	public void AfterPostTransition () {
		// If there was a post transition
		if (postScript != null) {
			// Discard the transition
			postScript.Discard();
		}

		// Return control to the player
		GameController.playerHasControl = true;
	}
}
