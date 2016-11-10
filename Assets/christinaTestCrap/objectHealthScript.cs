using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]


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

	}

	void OnTriggerStay(Collider other){


		
		if (other.tag == "Player"){

			if (objectBroken == true) {
				//if player presses REPAIR BUTTON
				if (other.GetComponent<playerController>().player.GetButtonDown("Action1")) { //change this to interact button
					//print("cool!");
					currentObjectHealth += repairAmount;
					//play fix noise
					other.GetComponent<AudioSource> ().Play ();

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

			if (objectBroken == false) {

				//does vampire need to do anything to break objects?
				if (other.GetComponent<playerController> ().player.GetButtonDown ("Action1")) {

					currentObjectHealth -= repairAmount; //change this to a unique vampire variable?
					//play vampire "ehheh" sound



					//if object health 0 break
					if (currentObjectHealth <= 0f) {
						other.GetComponent<AudioSource>().Play();
						BreakObject ();
					}
				}
			}
		}
	}



	public void BreakObject(){
		objectBroken = true;
		//play break sound?
		GetComponent<AudioSource>().Play();
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
