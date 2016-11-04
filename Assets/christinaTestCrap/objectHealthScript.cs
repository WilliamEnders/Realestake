using UnityEngine;
using System.Collections;

public class objectHealthScript : MonoBehaviour {

	public float scoreValue; //amount the object's state affects the House Health   
	public float currentObjectHealth; //amount of "health" the object currently has
	public float totalObjectHealth; //amount of "health" the object needs to be repaired
	public float repairAmount; //amount of health added to object when a player hits the repair button
	public float repairDelay; //amount of time before the player can hit the repair button again
	public bool objectBroken; //is the object broken or not?
	private float breakdownTimer; //start a timer to when the object is able to breakdown again
	private bool nearObject;
	private int playerCount;



	void Start () {
		playerCount = 0;
	}
	

	void Update () {
		//print ("Object is broken: " + objectBroken);
		TempBrokenIndicator();



		if (playerCount == 0) {
			nearObject = false;
		} else {
			nearObject = true;
		}

	}

	void OnTriggerEnter(Collider other){


		
		if (other.tag == "Player"){
			++playerCount;

			if (objectBroken == true) {
				//if player presses REPAIR BUTTON
				if (other.GetComponent<playerController>().player.GetButtonDown("Action1")) { //change this to interact button
					//print("cool!");
					currentObjectHealth += repairAmount;
					//print ("Player hit space");
					//print ("Object Health: " + currentObjectHealth);

					//if objectHealth reaches 100% through repair, add to house score
					if (currentObjectHealth > totalObjectHealth) {
						objectBroken = false;
						ScoreController.houseHealth += scoreValue;
						//start breakdownTimer 
					}
				}
			}
		}

		if (other.tag == "Vampire") {
			++playerCount;

			if (objectBroken == false) {

				//does vampire need to do anything to break objects?
				if (other.GetComponent<playerController> ().player.GetButtonDown ("Action1")) {

					currentObjectHealth -= repairAmount; //change this to a unique vampire variable?

					//if objectHealth reaches 0, the object is broken
					if (currentObjectHealth < totalObjectHealth) {
						ScoreController.houseHealth -= scoreValue;
					}
					if (currentObjectHealth <= 0f) {
						BreakObject ();
					}
				}
			}
		}

		Debug.Log ("Players near object = " + playerCount + "and nearObject is " + nearObject);
	}

	void OnTriggerExit(Collider other){

		if (other.tag == "Vampire") {
			--playerCount;
		}

		if (other.tag == "Player") {
			--playerCount;
		}

		Debug.Log ("Players near object = " + playerCount + "and nearObject is " + nearObject);
	}




	public void BreakObject(){
		objectBroken = true;
		currentObjectHealth = 0;
		ScoreController.houseHealth -= scoreValue;
	}

	void TempBrokenIndicator(){
		if (objectBroken == true) {
			gameObject.GetComponent<Renderer>().material.color = Color.red;
		} else {
			gameObject.GetComponent<Renderer>().material.color = Color.white;
		}
	
	}


}
