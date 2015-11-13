using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Ball;

public class Player : Ball {

	private float cubeLength;
    
	public GameManager gameManager;
	public CubeManager cubeManager;
	public GameObject triggerWalls;


	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ();
		cubeManager = GameObject.FindGameObjectsWithTag ("Cube").GetComponent<CubeManager> ();
		triggerWalls = GameObject.FindGameObjectWithTag("triggerWalls");
		cubeLength = cubeManager.gameObject.transform.lossyScale.x;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnTriggerExit(Collider other) {



		if (other.tag == "up") {

			cubeManager.up = true;
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
	public void OnTrigerEnter(Collider other) {
	

		if (other is Token) {
			Token token = other.GetComponent<Token> ();
			gameManager.playerAddsToScore (token.scoreValue);
		} else if (other is Damage) {
			Damage damage = other.GetComponent<Damage>();
			gameManager.playerTakesDamage(damage.damageValue);
		} else if(other is PowerUp){
			//do power up stuff
			Debug.Log("Player recieves a power up!");
		}

	}

}
