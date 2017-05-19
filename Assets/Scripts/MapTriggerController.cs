using UnityEngine;
using System.Collections;

public class MapTriggerController : MonoBehaviour {

	// Public Variables
	public GameObject newMap;			// map that will be switched to when this trigger is hit
	public Vector2 startPosition;		// player's position on the new map
	public GameObject preTransition;	// transition that will be used before the new map is loaded
	public GameObject postTransition;	// transition that will be used after the new map is loaded

	// Private Variables
	private GameObject preTransitionInstance;	// instance of transition that will be used before new map is loaded
	private GameObject postTransitionInstance;	// instance of transition that will be used after new map is loaded
	private Transition preScript;				// reference to script used by the pre transition
	private Transition postScript;				// reference to script used by the post transition


	// Unity Callbacks
	void OnTriggerEnter2D (Collider2D other) {
		// If it is the player that hit this trigger
		if (other.gameObject.tag == "Player") {
			GameController.playerHasControl = false; // Remove control from the player
			GameController.ResetPlayerVelocity(); // Stop the player from moving

			// If a pre transition has been defined
			if (preTransition != null) {
				// Make a new instance of the transition
				preTransitionInstance = Instantiate(preTransition, transform.position, Quaternion.identity) as GameObject;
				preScript = preTransitionInstance.GetComponent<Transition>(); // Get the transition script component from the transition
				preScript.callback = AfterPreTransition; // Set the callback of the transition to the function AfterPreTransition
			} else {
				AfterPreTransition(); // If no transition is defined, then call AfterPreTransition
			}
		}
	}


	// Public Functions
	public void AfterPreTransition () {
		GameController.SwapMap(newMap); // Tell the game controller to swap to the new map
		GameController.SetPlayerPosition(startPosition); // Set the player's position to the new position on the map
		// If there was a pre transition
		if (preScript != null) {
			preScript.Discard(); // Discard the transition
		}

		// If a post transition has been defined
		if (postTransition != null) {
			// Make a new instances of the transition
			postTransitionInstance = Instantiate(postTransition, transform.position, Quaternion.identity) as GameObject;
			postScript = postTransitionInstance.GetComponent<Transition>(); // Get the transition script component of the transition
			postScript.callback = AfterPostTransition; // Set the callback of the transition to the function AfterPostTransition
		} else {
			AfterPostTransition(); // If no transition is defined, then call AfterPostTransition
		}
	}

	public void AfterPostTransition () {
		// If there was a post transition
		if (postScript != null) {
			postScript.Discard(); // Discard the transition
		}
		GameController.playerHasControl = true; // Return control to the player
	}
}
