using UnityEngine;
using System.Collections;

public class camFollow : MonoBehaviour {

	public Transform player;
	public Vector3 offSet;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = player.position + offSet;
	}
}
