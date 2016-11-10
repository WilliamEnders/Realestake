using UnityEngine;
using System.Collections;
using Rewired;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour {

	public int playerId;
	public Player player;

	// Use this for initialization
	void Start () {
		player = ReInput.players.GetPlayer(playerId);
	}
	
	// Update is called once per frame
	void Update () {
		if(player.GetAnyButtonDown()){
			SceneManager.LoadScene (1);
		}
	}
}
