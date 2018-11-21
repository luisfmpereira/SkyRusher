using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnController : MonoBehaviour {

	public GameObject [] Obstacles;
	public void SpawnNew(){
		var newSpawn = (int)Random.Range(0,Obstacles.Length);
		Obstacles[newSpawn].gameObject.SetActive(true);
	}
}