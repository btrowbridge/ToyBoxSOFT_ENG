using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Ball;

public class Player : Ball {

	private float cubeLength; // reference to the cube length
    
	public GameManager gameManager; //reference to the gameManager
	public CubeManager cubeManager; // reference to the cube manager
	public GameObject triggerWalls; //reference to the trigger walls


	// Use this for initialization
	void Start () {

		//find the objects in the game scene used for reference
		gameManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ();
		cubeManager = GameObject.FindGameObjectWithTag ("Cube").GetComponent<CubeManager> ();
		triggerWalls = GameObject.FindGameObjectWithTag("triggerWalls");


		cubeLength = cubeManager.gameObject.transform.lossyScale.x; //length is equal to the scale of the cube
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//when player exits a collider
	//Note: we use this for smoothe rotation of the cube after exiting a trigger wall
	public void OnTriggerExit(Collider other) {


		// recognize which trigger wall the player hits
		if (other.tag == "up") {

			cubeManager.up = true; //cube movement flag

			//move the trigger walls to the nextlocation for the cube
			triggerWalls.transform.position.x += cubeLength; 

		} else if (other.tag == "down") {
			cubeManager.down = true;
			triggerWalls.transform.position.x -= cubeLength;

		} else if (other.tag == "left") {
			cubeManager.left = true;
			triggerWalls.transform.position.z += cubeLength;

		} else if (other.tag == "right") {
			cubeManager.right = true;
			triggerWalls.transform.position.z -= cubeLength;

		}


		
	}

	//called when player enters a trigger
	//Note: we use this when colliding with collectables
	public void OnTrigerEnter(Collider other) {
	
		//we Identify the apropriate collectable and execute the apropriate game manager function
		if (other is Token) {
			Token token = other.GetComponent<Token> ();
			gameManager.playerAddsToScore (token.scoreValue); //add score
		} else if (other is Damage) {
			Damage damage = other.GetComponent<Damage>();
			gameManager.playerTakesDamage(damage.damageValue); //take damage
		} else if(other is PowerUp){
			//do power up stuff
			Debug.Log("Player recieves a power up!");
		}

	}

}
