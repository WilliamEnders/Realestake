using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

	public static float houseHealth;
	public float houseHealthCap;
	public int objectValue; //stand in for controlling the value of house objects; may need multiple
	public Text scoreText;
	private float timeLeft;
	public float roundTime;
	public float realtorWinAmount;
	private bool isGameOver = false;
	public Slider healthBarSlider; //health bar slider
	public Image Fill; //the health bar's fill

	void Start () {
		UpdateScore ();
		houseHealth = 75f;//housescore starts at 50
		healthBarSlider.minValue = 0f;
		healthBarSlider.maxValue = houseHealthCap;

	}
	

	void Update () {
		UpdateScore ();
		HealthBarColors ();

		timeLeft -= Time.deltaTime;
		//print (timeLeft);
		if (timeLeft <= -roundTime) {
			RoundEnd ();
			//print ("Round Done!");

		}

		//housescore = 0-100; Cap it so can't collect higher or lower (feel free to remove for balance)
		if (houseHealth > houseHealthCap){
			houseHealth = houseHealthCap;
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
		//scoreText.text = "Score: " + houseHealth;
		healthBarSlider.value = houseHealth;
	}

	void HealthBarColors(){
		if (houseHealth > realtorWinAmount){
			Fill.color = Color.green;
		}

		if (houseHealth <= realtorWinAmount){
			Fill.color = Color.red;
		}
	}

	void RoundEnd(){

		isGameOver = true;

		if (houseHealth > realtorWinAmount){
			scoreText.text = "Round Over! Realtors Win!";
		}

		if (houseHealth <= realtorWinAmount){
			scoreText.text = "Round Over! Vampire Wins!";
		}
	}


}
