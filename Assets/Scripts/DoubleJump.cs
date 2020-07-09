using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour {

	float dirX;

	[SerializeField]
	float jumpForce = 500f, moveSpeed = 5f;

	Rigidbody2D rb;
	Collision2D col;

	bool doubleJumpAllowed = false;
	bool onTheGround = false;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

	void OnCollisionEnter(Collision collision){
    Debug.Log("Entered");
		if (collision.gameObject.CompareTag("Ground"))
		{
			onTheGround = true;
		}
	}

	void OnCollisionExit(Collision collision){
    Debug.Log("Exited");
		if (collision.gameObject.CompareTag("Ground"))
		{
			onTheGround = false;
		}
	}
		
	// Update is called once per frame
	void Update () {
		
		
		if (onTheGround)
			doubleJumpAllowed = true;

		if (onTheGround && Input.GetButtonDown ("Jump")) {
			Jump ();
		} else if (doubleJumpAllowed && Input.GetButtonDown ("Jump")) {
			Jump ();
			doubleJumpAllowed = false;
		}
		
		dirX = Input.GetAxis ("Horizontal") * moveSpeed;

	}

	void FixedUpdate()
	{
		
		rb.velocity = new Vector2 (dirX, rb.velocity.y);
	}

	void Jump()
	{
		rb.velocity = new Vector2 (rb.velocity.x, 0f);;
		rb.AddForce (Vector2.up * jumpForce);
	}

}
