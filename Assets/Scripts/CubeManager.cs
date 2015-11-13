using UnityEngine;
using System.Collections;

public class CubeManager : MonoBehaviour {

	private Transform target;	//used for the target rotation

    public bool up, down, left, right = false;	//Flags for cube movement
	public float rotateSpeed = 3;				//rotation speed of cube
	
	public GameObject triggerWalls; // reference to trigger walls
	public GameObject player;		//reference to player object

	// Use this for initialization
	void Start () {
		//find referenced objects in game scene
		triggerWalls = GameObject.FindGameObjectWithTag ("TrggerWalls");
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {

		if (up || down || left || right){

			//find apropriate axis of rotation relative to position of trigger walls
			if (up){
				target = triggerWalls.transform - Vector3(gameObject.transform.lossyScale.x/2,0,0);
			}
			else if(down){
				target = triggerWalls.transform + Vector3(gameObject.transform.lossyScale.x/2,0,0)
			}
			else if (left){
				target = triggerWalls.transform - Vector3(0,0,gameObject.transform.lossyScale.z/2)
			}
			else if (right){
				target = triggerWalls.transform + Vector3(0,0,gameObject.transform.lossyScale.z/2)
			}
			
			Vector3 relativePos = target.position - transform.position;
			Quaternion rotation = Quaternion.LookRotation(relativePos);
			
			Quaternion current = transform.localRotation;
			
			transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime);
			transform.Translate(0, rotateSpeed * Time.deltaTime, 0)
		}

		//if square is under the player, stop all movement
		//Note: the player objects orientation will be frozen on the xz-plane
		if((player.transform.position.y - gameObject.transform.position.y) == (gameObject.transform.lossyScale.y / 2)){
			up = false;
			down = false;
			left = false;
			right = false;
		}


	}
    void FixedUpdate() {
	
	}
}
