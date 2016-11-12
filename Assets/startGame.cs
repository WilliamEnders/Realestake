using UnityEngine;
using System.Collections;
using Rewired;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour {

	public int playerId;
	public Player player;
	private bool canStart;

	// Use this for initialization
	void Start () {
		canStart = false;
		player = ReInput.players.GetPlayer(playerId);
		Invoke ("CanStart",16f);

	}
	
	// Update is called once per frame
	void Update () {
		if(player.GetAnyButtonDown() && canStart){
			GetComponent<AudioSource>().Play();
			SceneManager.LoadScene (1);
		}
	}

	void CanStart(){
		canStart = true;
	}

}
