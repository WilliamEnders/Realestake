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

	void OnColliderEnter(Collider other){
		//if player.tag=realtor, press button, +score
		if (other.tag == "Player"){
			ScoreController.houseHealth += scoreValue;
		}

		if (other.tag == "Vampire"){
			ScoreController.houseHealth -= scoreValue;
		}


		//if player.tag=vampire, press button, -score
	}
}
