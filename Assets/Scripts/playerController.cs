using UnityEngine;
using System.Collections;
using Rewired;
[RequireComponent(typeof(AudioSource))]

public class playerController : MonoBehaviour {

	public int playerId = 0;
	public Player player;
	public Rigidbody rb;
	public float moveSpeed;
	public float jumpHeight;
	public SpriteRenderer sr;
	public Animator anim;
	public bool haveTool = false;
	public bool canStun;

	public AudioClip walkIndoors;
	public AudioClip walkOutdoors;
	public AudioClip stunPlayer;
	public AudioClip pickupTool;
	public AudioClip dropTool;
	private AudioSource audio;


	// Use this for initialization

	void Awake(){

		player = ReInput.players.GetPlayer(playerId);	
	}

	void Start () {
		canStun = true;
		rb = GetComponent<Rigidbody> ();
		sr = GetComponent<SpriteRenderer> ();
		anim = GetComponent<Animator> ();
		audio = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		Vector2 move = new Vector2 (player.GetAxis ("HorizontalMove"), player.GetAxis ("VerticalMove")) * moveSpeed;
		Vector3 movement = new Vector3 (move.x, rb.velocity.y, move.y);
		rb.velocity = movement;

		sr.flipX = move.x < 0;

		if (move.x != 0 || move.y != 0) {
			anim.SetBool ("Walk", true);
			//audio.Play(walkIndoors);

			//play walk sound; change based on outdoor/indoor?

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
	void CanStun(){
		canStun = true;
	}
		
	void OnTriggerStay(Collider other){

		if (other.CompareTag ("Vampire")) {
			if (other.GetComponent<playerController> ().player.GetButtonDown ("Action1") && moveSpeed > 0 && canStun) {
				print ("stunned!");
				audio.PlayOneShot(stunPlayer);
				moveSpeed = 0;
				canStun = false;
				Invoke ("WakeUp", 5f);
				Invoke ("CanStun", 10f);
			}
		}
		if ((other.CompareTag("tool")) && player.GetButtonDown("Action2")) {
			print ("pickup");
			//play pickup sound
			audio.PlayOneShot(pickupTool);
			other.transform.parent = transform;
			haveTool = true;
		}
		if ((haveTool = true) && player.GetButtonDown("Action3")) {
			print ("tool drop");
			audio.PlayOneShot(dropTool);
			other.transform.parent = null;
		}
	}
}
