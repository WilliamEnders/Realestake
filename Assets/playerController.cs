using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

	public Rigidbody rb;
	public float moveSpeed;
	public float jumpHeight;
	public SpriteRenderer sr;
	public Animator anim;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		sr = GetComponent<SpriteRenderer> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetAxis ("Horizontal") < 0) {
			sr.flipX = true;
		}
		if (Input.GetAxis ("Horizontal") > 0) {
			sr.flipX = false;
		}

		Vector2 move = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical")) * moveSpeed;
		Vector3 movement = new Vector3 (move.x, rb.velocity.y, move.y);
		rb.velocity = movement;

		if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0) {
			anim.SetBool ("Walk", true);
		}else if (Input.GetAxis ("Vertical") > 0 || Input.GetAxis ("Vertical") < 0) {
			anim.SetBool ("Walk", true);
		}else{ 
			anim.SetBool ("Walk", false);
		}
		 
		/*if (Input.GetKeyDown(KeyCode.Space)) {
			rb.AddForce (Vector3.up * jumpHeight);
			anim.SetBool ("Jump", true);
		} else {
			anim.SetBool ("Jump", false);
		}*/
	}
}
