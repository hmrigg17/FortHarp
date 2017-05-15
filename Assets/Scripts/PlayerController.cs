using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float acceleration;
	public float moveSpeed;

	private Rigidbody2D rb;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
		if (GameController.playerHasControl) {
			float moveHorizontal = Input.GetAxis("Horizontal") * moveSpeed;
			float moveVertical = Input.GetAxis("Vertical") * moveSpeed;

			rb.velocity = new Vector2(moveHorizontal, moveVertical);
		}
	}
}