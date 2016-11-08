using UnityEngine;
using System.Collections;
using Rewired;

public class playerController : MonoBehaviour {

	public int playerId = 0;
	public Player player;
	public int stunNum;
	public Rigidbody rb;
	public float moveSpeed;
	public float jumpHeight;
	public SpriteRenderer sr;
	public Animator anim;
	public bool haveTool = false;

	// Use this for initialization

	void Awake(){

		player = ReInput.players.GetPlayer(playerId);	
	}

	void Start () {
		rb = GetComponent<Rigidbody> ();
		sr = GetComponent<SpriteRenderer> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		Vector2 move = new Vector2 (player.GetAxis ("HorizontalMove"), player.GetAxis ("VerticalMove")) * moveSpeed;
		Vector3 movement = new Vector3 (move.x, rb.velocity.y, move.y);
		rb.velocity = movement;

		sr.flipX = move.x < 0;

		if (move.x != 0 || move.y != 0) {
			anim.SetBool ("Walk", true);
		}else{ 
			anim.SetBool ("Walk", false);
		}

		 /*
		if (player.GetButtonDown("Jump")) {
			rb.AddForce (Vector3.up * jumpHeight);
			anim.SetBool ("Jump", true);
		} else {
			anim.SetBool ("Jump", false);
		}
		*/
	}

	void WakeUp(){
		moveSpeed = 5;
	}
		
	void OnTriggerStay(Collider other){

		if (other.CompareTag ("Vampire")) {
			if (other.GetComponent<playerController> ().player.GetButtonDown ("Action1") && stunNum > 0 && moveSpeed > 0) {
				print ("stunned!");
				stunNum--;
				moveSpeed = 0;
				Invoke ("WakeUp", 2f);
			}
		}
		if ((other.CompareTag("tool")) && player.GetButtonDown("Action2")) {
			print ("pickup");
			other.transform.parent = transform;
			haveTool = true;
		}
		if ((haveTool = true) && player.GetButtonDown("Action3")) {
			print ("tool drop");
			other.transform.parent = null;
		}
	}
}
