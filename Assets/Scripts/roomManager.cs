using UnityEngine;
using System.Collections;

public class roomManager : MonoBehaviour {

	public int peopleInRoom;
	public Renderer wall;


	// Use this for initialization
	void Start () {
		peopleInRoom = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider info){
		if(info.CompareTag("Player")){
			peopleInRoom++;
			WallTransparent (true);
		}
	}

	void OnTriggerExit(Collider info){
		if(info.CompareTag("Player")){
			peopleInRoom--;
			if(peopleInRoom == 0){
			WallTransparent (false);
			}
		}
	}

	void WallTransparent(bool invisible){
		if (invisible) {
			wall.material.color = new Color (1, 1, 1, 0.5f);
		} else {
			wall.material.color = new Color (1, 1, 1, 1f);
		}
	}

}
