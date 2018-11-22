using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreHandler : MonoBehaviour {

	public float score;
	playerController playerController;
	public Text scoreText;
	public Text highscoreText;

	void Start(){
		playerController = GameObject.FindGameObjectWithTag("Player").
		GetComponent<playerController>();
	}

	public void AddScore(float amountToAdd){
		score += amountToAdd;
	}


	void Update(){
		if(playerController.canMovePlayer){
			scoreText.gameObject.SetActive(true);
			AddScore((Time.deltaTime/2f));
			scoreText.text = "Score: " + ((int)score).ToString();
			}
		else
			scoreText.text = "Highscore: " + ((int)PlayerPrefs.GetFloat("Highscore")).ToString();
	}

	public void UpdateHighscore(){
		if(score > PlayerPrefs.GetFloat("Highscore")){
			PlayerPrefs.SetFloat("Highscore",score);
		}
	}
}
