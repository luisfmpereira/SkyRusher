using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnController : MonoBehaviour {

	public GameObject [] Obstacles;
	public void SpawnNew(){
		var newSpawn = (int)Random.Range(0,Obstacles.Length);
		Obstacles[newSpawn].gameObject.SetActive(true);

		var numChild = Obstacles[newSpawn].transform.childCount;
		if (numChild > 1)
			Obstacles[newSpawn].transform.GetChild(numChild-1).gameObject.SetActive(true);
	}
}