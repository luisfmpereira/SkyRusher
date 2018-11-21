using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstInteraction : MonoBehaviour {
	
	playerController player;
	spawnController spawnController;
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();
		spawnController = GameObject.FindGameObjectWithTag("Spawn").GetComponent<spawnController>();
	}
	
	void Update () {
		if (Input.GetMouseButtonDown(0) && !player.canMovePlayer) {
			player.canMovePlayer = true;
			spawnController.SpawnNew();
		}
	}
}
