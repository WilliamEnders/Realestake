using UnityEngine;
using System.Collections;

public class testScoreCollision : MonoBehaviour {

	public float scoreValue = 10f;     


	// Use this for initialization
	void Start () {
	 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){

		print ("Something Collided");
		//if player.tag=realtor, press button, +score
		if (other.tag == "Player"){
			ScoreController.houseHealth += scoreValue;
			print ("Player Collided");
		}

		if (other.tag == "Vampire"){
			ScoreController.houseHealth -= scoreValue;
		}


		//if player.tag=vampire, press button, -score
	}
}
