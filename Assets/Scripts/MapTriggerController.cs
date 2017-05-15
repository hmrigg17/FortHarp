using UnityEngine;
using System.Collections;

public class MapTriggerController : MonoBehaviour {

	public GameObject newMap;
	public Vector2 startPosition;

	public GameObject preTransition;
	public GameObject postTransition;

	private GameObject preTransitionInstance;
	private GameObject postTransitionInstance;

	private Transition preScript;
	private Transition postScript;

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Player") {
			GameController.playerHasControl = false;
			GameController.ResetPlayerVelocity();
			if (preTransition != null) {
				preTransitionInstance = Instantiate(preTransition, transform.position, Quaternion.identity) as GameObject;
				preScript = preTransitionInstance.GetComponent<Transition>();
				preScript.callback = AfterPreTransition;
			} else {
				AfterPreTransition();
			}
		}
	}

	public void AfterPreTransition () {
		GameController.SwapMap(newMap);
		GameController.SetPlayerPosition(startPosition);

		if (preScript != null) {
			preScript.Discard();
		}

		if (postTransition != null) {
			postTransitionInstance = Instantiate(postTransition, transform.position, Quaternion.identity) as GameObject;
			postScript = postTransitionInstance.GetComponent<Transition>();
			postScript.callback = AfterPostTransition;
		} else {
			AfterPostTransition();
		}
	}

	public void AfterPostTransition () {
		if (postScript != null) {
			postScript.Discard();
		}

		GameController.playerHasControl = true;
	}
}
