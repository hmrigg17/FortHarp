using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject initialMap;
	public GameObject initialUI;
	public GameObject player;

	public static bool playerHasControl;

	private static GameObject currentMap;
	private static GameObject currentPlayer;

	void Start () {
		currentMap = Instantiate(initialMap, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
		currentPlayer = player;
		playerHasControl = true;
	}

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
