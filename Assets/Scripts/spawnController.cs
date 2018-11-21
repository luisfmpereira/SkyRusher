using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnController : MonoBehaviour {

	public GameObject [] Obstacles;

	
	void Start () {
		
	}
	
	void Update () {
		
	}


	public void SpawnNew(){
		var newSpawn = (int)Random.Range(0,Obstacles.Length);
		Obstacles[newSpawn].gameObject.SetActive(true);
	}
}