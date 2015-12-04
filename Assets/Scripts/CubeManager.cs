using UnityEngine;
using System.Collections;

public class CubeManager : MonoBehaviour {

	

    public bool up, down, left, right = false;	//Flags for cube movement
	public float rotateSpeed = 3;				//rotation speed of cube
	
	public GameObject triggerWalls; // reference to trigger walls
	public GameObject player;		//reference to player object
    public Transform target;   //used for the target rotation
   
                                // Use this for initialization
    void Start () {
		//find referenced objects in game scene
		triggerWalls = GameObject.FindGameObjectWithTag ("TriggerWalls");
		player = GameObject.FindGameObjectWithTag ("Player");


    }

    // Update is called once per frame
    void Update () {

        if (up) {
            transform.RotateAround(target.position, Vector3.left, rotateSpeed);
        }
        else if (down) {
            transform.RotateAround(target.position, Vector3.right, rotateSpeed);
        }
        else if (left) {
            transform.RotateAround(target.position, Vector3.back, rotateSpeed);
        }
        else if (right) {
            transform.RotateAround(target.position, Vector3.forward, rotateSpeed);
        }

       


    }
    void OnTriggerEnter(Collider other) {
        Debug.Log.
        if (other.tag == "Floor")
        {
            if (up)
            {
                triggerWalls.transform.position += Vector3.forward * gameObject.transform.lossyScale.x;
            }
            else if (down)
            {
                triggerWalls.transform.position += Vector3.back * gameObject.transform.lossyScale.x;
            }
            else if (left)
            {
                triggerWalls.transform.position += Vector3.left * gameObject.transform.lossyScale.x;
            }
            else if (right)
            {
                triggerWalls.transform.position += Vector3.right * gameObject.transform.lossyScale.x;
            }
            up = false;
            down = false;
            left = false;
            right = false;
        }
    }
    //if square is under the player, stop all movement
	//Note: the player objects orientation will be frozen on the xz-plane

    void FixedUpdate() {
	
	}
}
