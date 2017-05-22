using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	// [https://www.youtube.com/watch?v=Tm2L-_0eIeY&list=PLiyfvmtjWC_X6e0EYLPczO9tNCkm2dzkm&index=2]
	// [https://www.youtube.com/watch?v=Oao-A7bkve0&index=3&list=PLiyfvmtjWC_X6e0EYLPczO9tNCkm2dzkm]

	// Public Variables
	public float moveSpeed; // The speed at which the player moves


	// Private Variables
	private Rigidbody2D rb; // The instance of the rigidbody for the player
	private Animator anim;
	private static bool playerExists;

	void Start () {
		rb = GetComponent<Rigidbody2D>(); // Get the player's rigidbody component
		anim = GetComponent<Animator>();

		if (!playerExists) { // [https://www.youtube.com/watch?v=tevpiu8CW6I&index=10&list=PLiyfvmtjWC_X6e0EYLPczO9tNCkm2dzkm]
			playerExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} else {
			Destroy (gameObject);
		}
	}
	
	void Update () {
		// Get the input amounts
		float moveHorizontal = Input.GetAxis("Horizontal") * moveSpeed;
		float moveVertical = Input.GetAxis("Vertical") * moveSpeed;

		if (Input.GetAxisRaw ("Horizontal") != 0 || Input.GetAxisRaw ("Vertical") != 0)
			rb.velocity = new Vector2 (moveHorizontal, moveVertical); // Set the player's velocity to the correct move amount
		else // stops character from sliding after key is released
			rb.velocity = new Vector2 (0f, 0f);

		// animator controller things
		anim.SetFloat ("MoveX", Input.GetAxisRaw ("Horizontal"));
		anim.SetFloat ("MoveY", Input.GetAxisRaw ("Vertical"));
	}
}