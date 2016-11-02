using UnityEngine;
using System.Collections;

public class objectController : MonoBehaviour {

	private int repObjCount;
	public float maxTime = 5;
	public float minTime = 2;
	private float spawnTime; //random time interval
	private float time; //current time
	public GameObject[] repObjects;

	//cap number of items that can be broken at a time (per level)
	//may need to check day/night status to increase diffuclty per day or per time of day, etc.


	void Start () {

		SetRandomTime();
		time = minTime;

		//GameObject[] repObjects = new GameObject[repObjCount];


		//for (int i = 1; i < repObjCount; i++) {

			//if object is broken
		repObjects = GameObject.FindGameObjectsWithTag ("repObject");

		//Debug.Log (repObjects.Length);

		//}

		foreach(GameObject repairObj in repObjects)
		{
			//set logic for random break at scene load
			//check objects' bool for broken/notbroken?

			if(repairObj.GetComponent<objectHealthScript>().objectBroken == false){
				//random number generator, check if number is above#
				repairObj.GetComponent<objectHealthScript> ().objectBroken = true;
				//exit loop ("break") if it is broken
			}
		}
	}
	

	void Update () {
	
	}

	void FixedUpdate(){

		//Counts up
		time += Time.deltaTime; //reset timer when an object gets broken

		//Check if its the right time to spawn the object
		if(time >= spawnTime){
			RandomBreak();
			SetRandomTime();
		}

	}


	void SetRandomTime(){ //Sets the random time between minTime and maxTime
		spawnTime = Random.Range(minTime, maxTime);
	}

	void RandomBreak(){ //break random #(variable) at random interval (variable)
		time = minTime;
	}
}
