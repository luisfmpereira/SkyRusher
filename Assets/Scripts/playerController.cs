using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour {
private Vector3 FirstTransform;
private Vector3 DirectionTransform;
private float DeltaX;
private float DeltaY;
public float speedX;
public float speedY;
public float MaxX;
public float MaxY;
public float MinX;
public float MinY;
private bool mouseButtonUp;
public bool canMovePlayer;

public scoreHandler scoreHandler;
public Transform playerT;

void Start(){
    playerT = GetComponent<Transform>();
    scoreHandler = GameObject.FindGameObjectWithTag("ScoreHandler").GetComponent<scoreHandler>();
}
void Update()
{
    if(canMovePlayer){
 		GetInformations();
   		UpdatePlayerTransform();
    }
   
}

void GetInformations()
{
    if (Input.GetMouseButtonDown(0)) {
        speedX = 0.5f;
        speedY = 0.5f;
        FirstTransform = Camera.main.ScreenToViewportPoint(Input.mousePosition);
    }

    if (Input.GetMouseButton(0)){
        DirectionTransform = Camera.main.ScreenToViewportPoint(Input.mousePosition);
    }

    if (Input.GetMouseButtonUp(0)) {
        mouseButtonUp = true;
    }
    if (mouseButtonUp) {
        if (speedX > 0)
            speedX -= 3 * Time.deltaTime;
        else {
            speedX = 0;
            mouseButtonUp = false;
			}
		if (speedY > 0)
            speedY -= 3 * Time.deltaTime;
        else { 
			speedY = 0;
                mouseButtonUp = false;
            }
        }
    }

    void UpdatePlayerTransform()
    {
        DeltaX = (FirstTransform.x - DirectionTransform.x);
        DeltaY = (FirstTransform.y - DirectionTransform.y);

        playerT.position -= new Vector3(DeltaX * speedX, DeltaY * speedY, 0);

        if (playerT.position.x < MinX)
            playerT.position = new Vector3(MinX, playerT.position.y, playerT.position.z);

        if (playerT.position.x > MaxX)
            playerT.position = new Vector3(MaxX, playerT.position.y, playerT.position.z);

        if (playerT.position.y > MaxY)
            playerT.position = new Vector3(playerT.position.x, MaxY, playerT.position.z);

        if (playerT.position.y < MinY)
            playerT.position = new Vector3(playerT.position.x, MinY, playerT.position.z);

    }



    void OnCollisionEnter(Collision other){

        if(other.gameObject.CompareTag("Obstacle")){
            scoreHandler.UpdateHighscore();
            SceneManager.LoadScene(0);
                        
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Collectible")){
            other.gameObject.SetActive(false);
            scoreHandler.AddScore(10);

        }
    }
}
