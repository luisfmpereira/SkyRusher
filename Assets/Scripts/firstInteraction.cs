using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class firstInteraction : MonoBehaviour {
	
	playerController player;
	spawnController spawnController;
	public Text tapToStart;
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();
		spawnController = GameObject.FindGameObjectWithTag("Spawn").GetComponent<spawnController>();
	}
	
	void Update () {
		if (Input.GetMouseButtonDown(0) && !player.canMovePlayer) {
			tapToStart.enabled = false;
			player.canMovePlayer = true;
			spawnController.SpawnNew();
		}
	}
}
