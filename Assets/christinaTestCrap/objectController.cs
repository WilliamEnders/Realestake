using UnityEngine;
using System.Collections;

public class objectController : MonoBehaviour {

	private int repObjCount;

	// Use this for initialization
	void Start () {
		GameObject[] repObjects = new GameObject[repObjCount];

		for (int i = 1; i < repObjCount; i++) {
			repObjects [i] = GameObject.FindWithTag ("repObject" + i);
		}

		foreach(GameObject repairObj in repObjects)
		{
			//set logic for random break at scene load
			//check objects' bool for broken/notbroken?

			if(repairObj.GetComponent<objectHealthScript>().objectBroken){
				//use this bool check to add/remove object from array?
			}
		}
	}
	

	void Update () {
	
	}

	void RandomBreak(){
		//break random #(variable) at random interval (variable)
	}
}
