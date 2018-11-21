using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveObstacle : MonoBehaviour {

	[SerializeField]
	private float moveSpeed;

	private GameObject endLocation;
	private GameObject spawnLocation;

	GameObject spawnController;

	void Start () {
		endLocation = GameObject.FindGameObjectWithTag("EndLocation");
		spawnLocation = GameObject.FindGameObjectWithTag("Spawn");
	}
	
	void Update () {
		move();
	}

	void move(){
		this.transform.position -= new Vector3(0,0,moveSpeed);

		if(this.transform.position.z <= endLocation.transform.position.z){
			this.gameObject.SetActive(false);
			this.gameObject.transform.position = spawnLocation.transform.position;
			spawnLocation.GetComponent<spawnController>().SpawnNew();
		}
	}
}
