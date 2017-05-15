using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	// Public Variables
	// The map to load when the game starts
	public GameObject initialMap;

	// The UI to load when the game starts
	public GameObject initialUI;

	// The instance of the player
	public GameObject player;


	// Public Static Variables
	// Whether or not the player has direct control of the character
	public static bool playerHasControl;


	// Private Static Variables
	// The instance of the currently loaded map
	private static GameObject currentMap;

	// The instance of the currently loaded UI
	private static GameObject currentPlayer;


	// Unity Callbacks
	void Start () {
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
