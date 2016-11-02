using UnityEngine;
using System.Collections;

public class objectHealthScript : MonoBehaviour {

	public float scoreValue; //amount the object's state affects the House Health   
	public float objectHealth; //amount of "health" the object needs to be repaired
	public float repairAmount; //amount of health added to object when a player hits the repair button
	public float repairDelay; //amount of time before the player can hit the repair button again
	public bool objectBroken; //is the object broken or not?
	private float breakdownTimer; //start a timer to when the object is able to breakdown again


	void Start () {

	}
	

	void Update () {
		//print ("Object is broken: " + objectBroken);
		TempBrokenIndicator();
	}

	void OnTriggerStay(Collider other){

		if (objectBroken == true) {
			//if player presses REPAIR BUTTON
			if (other.tag == "Player" && Input.GetKeyDown (KeyCode.Space)) { //change this to interact button

				objectHealth += repairAmount;
				print ("Player hit space");
				print ("Object Health: " + objectHealth);

				//if objectHealth reaches 100% through repair, add to house score
				if (objectHealth > 99f) {
					objectBroken = false;
					ScoreController.houseHealth += scoreValue;
					//start breakdownTimer 
				}
			}
		}

		if (objectBroken == false) {

			//does vampire need to do anything to break objects?
			if (other.tag == "Vampire") {

				objectHealth -= repairAmount; //change this to a unique vampire variable?

				//if objectHealth reaches 0, the object is broken
				if (objectHealth < 1f) {
					ScoreController.houseHealth -= scoreValue;

				}
			}
		}


	
	}

	void TempBrokenIndicator(){
		if (objectBroken == true) {
			gameObject.GetComponent<Renderer>().material.color = Color.red;
		} else {
			gameObject.GetComponent<Renderer>().material.color = Color.white;
		}
	
	}


}
