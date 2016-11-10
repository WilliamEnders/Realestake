using UnityEngine;
using System.Collections;

public class vampOutside : MonoBehaviour {

	public dayNightManager sun;
	public AudioClip vampBleh;
	private AudioSource audio;


	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		
		if(other.CompareTag("Vampire") && sun.day){
			audio.PlayOneShot(vampBleh);

			other.GetComponent<playerController> ().moveSpeed = 0.5f;	
		}
	}
	void OnTriggerStay(Collider other){
		if(other.CompareTag("Vampire") && !sun.day){
			other.GetComponent<playerController> ().moveSpeed = 5.5f;	
		}
	}
	void OnTriggerExit(Collider other){
		if(other.CompareTag("Vampire")){
			other.GetComponent<playerController> ().moveSpeed = 5.5f;	
		}
	}
}
