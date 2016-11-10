using UnityEngine;
using System.Collections;

public class dayNightManager : MonoBehaviour {

	private Light sun;
	private Vector3 dayRot;
	private Vector3 nightRot;
	public float cycleTime;
	public float lerpTime;
	public bool day;

	// Use this for initialization
	void Start () {
		day = true;
		sun = GetComponent<Light> ();
		dayRot = transform.localEulerAngles;
		nightRot = Vector3.Reflect (dayRot, Vector3.right);
		Invoke ("ChangeToDay",cycleTime);
	}

	// Update is called once per frame
	private void ChangeToDay(){
		StartCoroutine ("ToDay");
	}
	private void ChangeToNight(){
		StartCoroutine ("ToNight");
	}

	private IEnumerator ToNight(){
		float elapsedTime = 0;
		while(elapsedTime < lerpTime){
			transform.rotation = Quaternion.Lerp (transform.rotation,Quaternion.Euler(nightRot),elapsedTime/lerpTime);
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		day = false;
		Invoke ("ChangeToDay",cycleTime);
	}

	private IEnumerator ToDay(){
		float elapsedTime = 0;
		while(elapsedTime < lerpTime){
			transform.rotation = Quaternion.Lerp (transform.rotation,Quaternion.Euler(dayRot),elapsedTime/lerpTime);
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		day = true;
		Invoke ("ChangeToNight",cycleTime);
	}

}
