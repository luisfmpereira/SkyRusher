using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreHandler : MonoBehaviour {

	public float score;
	playerController playerController;

	void Start(){
		playerController = GameObject.FindGameObjectWithTag("Player").
		GetComponent<playerController>();
	}

	public void AddScore(float amountToAdd){
		score += amountToAdd;
	}


	void Update(){
		if(playerController.canMovePlayer)
			AddScore(Time.deltaTime);
	}
}
