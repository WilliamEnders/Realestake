using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

	public Rigidbody rb;
	public float moveSpeed = 10f;
	public float jumpHeight = 1000f;
	public SpriteRenderer sr;
	//float xScale;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		sr = GetComponent<SpriteRenderer> ();
		//xScale = transform.localScale.x;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		/*if (Input.GetAxis ("Horizontal") < 0) {
			sr.flipX = true;
		}
		if (Input.GetAxis ("Horizontal") > 0) {
			sr.flipX = false;
		}*/

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0f, moveVertical);
		rb.velocity = movement * moveSpeed;

		/*if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis ("Horizontal") < 0) {
			float moveX = Input.GetAxis ("Horizontal");
			rb.velocity = new Vector2 (moveX * moveSpeed, rb.velocity.y);
		}

		if(Input.GetAxis("Vertical") > 0 || Input.GetAxis("Vertical") < 0){
			float moveZ = Input.GetAxis ("Vertical");
			rb.velocity = new Vector2 */
		 
		if (Input.GetKeyDown(KeyCode.Space)) {
			rb.velocity = new Vector2 (rb.velocity.x, 0);
			rb.AddForce (new Vector2 (0, jumpHeight));
			print ("jump");
		}
	}
}
