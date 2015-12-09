using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Ball;

public class Player : MonoBehaviour{


    private Rigidbody r;
	public GameManager gameManager; //reference to the gameManager
	public CubeManager cubeManager; // reference to the cube manager
	public GameObject triggerWalls; //reference to the trigger walls
    


	// Use this for initialization
	void Start () {

		//find the objects in the game scene used for reference
		gameManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ();
		cubeManager = GameObject.FindGameObjectWithTag ("Cube").GetComponent<CubeManager> ();
        triggerWalls = GameObject.FindGameObjectWithTag("TriggerWalls");
        r = GetComponent<Rigidbody>();

		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y <= -10) {
            transform.position = cubeManager.transform.position + new Vector3(0, 15, 0);
        }
	}

	//when player exits a collider
	//Note: we use this for smoothe rotation of the cube after exiting a trigger wall
	public void OnTriggerExit(Collider other) {

        

		// recognize which trigger wall the player hits
		if (other.tag == "Up") {
            
            cubeManager.up = true; //cube movement flag
            //start rotation corouting
            StartCoroutine_Auto(cubeManager.rotate(other.gameObject.transform));
            
        } else if (other.tag == "Down") {
            
            cubeManager.down = true;
            StartCoroutine_Auto(cubeManager.rotate(other.gameObject.transform));

        } else if (other.tag == "Left") {
            
            cubeManager.left = true;
            StartCoroutine_Auto(cubeManager.rotate(other.gameObject.transform));

        } else if (other.tag == "Right") {
            
            cubeManager.right = true;
            StartCoroutine_Auto(cubeManager.rotate(other.gameObject.transform));
        } 

        
	}
    //called when player enters a trigger
    //Note: we use this when colliding with collectables
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Token"))
        {
            UnityEngine.Debug.Log("Player collects token");
            other.gameObject.SetActive(false);
            gameManager.playerAddsToScore(Token.scoreValue);
        }
        else if (other.CompareTag("Enemy")) {
            UnityEngine.Debug.Log("Player Hits enemy");
            gameManager.playerTakesDamage(Damage.damageValue);
            other.gameObject.SetActive(false);
            r.AddForce(( transform.position - other.transform.position)* 150);

        }
        else if (other.gameObject.GetComponent<PowerUp>())
        {
            //do power up stuff
            Debug.Log("Player recieves a power up!");
        }
    }

	//called when player enters a trigger
	//Note: we use this when colliding with collectables


}
