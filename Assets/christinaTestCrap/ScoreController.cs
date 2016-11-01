using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

	public static float houseHealth;
	public int objectValue; //stand in for controlling the value of house objects; may need multiple
	public Text scoreText;


	void Start () {
		UpdateScore ();
		houseHealth = 50f;//housescore starts at 50
	}
	

	void Update () {
		UpdateScore ();

		//if player.tag=realtor, do something, +score


		//if player.tag=vampire, do something, -score



		//housescore = 0-100; Cap it so can't collect h	igher or lower (feel free to remove for balance)
		if (houseHealth > 100f){
			houseHealth = 100f;
		}

		if (houseHealth < 0f){
			houseHealth = 0f;
		}

		//win conditions?

	}

	public void AddScore (int newScoreValue)
	{
		houseHealth += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore ()
	{
		scoreText.text = "Score: " + houseHealth;
	}
}
