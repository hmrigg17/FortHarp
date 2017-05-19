using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	// Public Variables
	public GameObject initialMap; // The map to load when the game starts
	public GameObject initialUI; // The UI to load when the game starts
	public GameObject player; // The instance of the player

	// Public Static Variables
	public static bool playerHasControl; // Whether or not the player has direct control of the character
	public static GameController instance = null;

	// Private Static Variables
	private static GameObject currentMap; // The instance of the currently loaded map
	private static GameObject currentPlayer; // The instance of the currently loaded UI


	// Unity Callbacks
	void Start () {
		// the following block was borrowed from the 2D Rogue-like Tutorial on Unity's website
		// [https://unity3d.com/learn/tutorials/projects/2d-roguelike-tutorial]
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		
		currentMap = Instantiate(initialMap, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
		currentPlayer = player;
		playerHasControl = true;
	}


	// Public Static Functions
	public static void SwapMap (GameObject newMap) {
		Destroy(currentMap);
		currentMap = Instantiate(newMap, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
	}

	public static void SetPlayerActive (bool active) {
		currentPlayer.SetActive(active);
	}

	public static void ResetPlayerVelocity () {
		currentPlayer.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
	}

	public static void SetPlayerPosition (Vector2 newPosition) {
		currentPlayer.transform.position = new Vector3(newPosition.x, newPosition.y, currentPlayer.transform.position.z);
	}
}
