using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Public Variables
	public float moveSpeed; // The speed at which the player moves


	// Private Variables
	private Rigidbody2D rb; // The instance of the rigidbody for the player

	void Start () {
		rb = GetComponent<Rigidbody2D>(); // Get the player's rigidbody component
	}
	
	void FixedUpdate () {
		// If the player has control
		if (GameController.playerHasControl) {
			// Get the input amounts
			float moveHorizontal = Input.GetAxis("Horizontal") * moveSpeed;
			float moveVertical = Input.GetAxis("Vertical") * moveSpeed;

			// Set the player's velocity to the correct move amount
			rb.velocity = new Vector2(moveHorizontal, moveVertical);
		}
	}
}