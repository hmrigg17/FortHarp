using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Public Variables
	// The speed at which the player moves
	public float moveSpeed;


	// Private Variables
	// The instance of the rigidbody for the player
	private Rigidbody2D rb;

	void Start () {
		// Get the player's rigidbody component
		rb = GetComponent<Rigidbody2D>();
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