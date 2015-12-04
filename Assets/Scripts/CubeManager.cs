using UnityEngine;
using System.Collections;

public class CubeManager : MonoBehaviour {

	

    public bool up, down, left, right = false;	//Flags for cube movement
	public float rotateSpeed = 3;               //rotation speed of cube

    public GameObject ghostBox;
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
    void FixedUpdate () {

        if (up) {
            transform.RotateAround(target.position, Vector3.left, rotateSpeed);

        }
        else if (down) {
            transform.RotateAround(target.position, Vector3.right, rotateSpeed);
            if (transform == ghostBox.transform)
            {
                Stop();
            }
        }
        else if (left) {
            transform.RotateAround(target.position, Vector3.back, rotateSpeed);
            if (transform == ghostBox.transform)
            {
                Stop();
            }
        }
        else if (right) {
            transform.RotateAround(target.position, Vector3.forward, rotateSpeed);
            if (transform == ghostBox.transform)
            {
                Stop();
            }
        }

       


    }
    public void rotateGhost() {
        if (up)
        {
            transform.RotateAround(target.position, Vector3.left, 90);
        }
        else if (down)
        {
            transform.RotateAround(target.position, Vector3.right, 90);

        }
        else if (left)
        {
            transform.RotateAround(target.position, Vector3.back, 90);
        }
        else if (right)
        {
            transform.RotateAround(target.position, Vector3.forward, 90);
        }
    }
    void Stop() {
        UnityEngine.Debug.Log("Box should stop");

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
    //if square is under the player, stop all movement
	//Note: the player objects orientation will be frozen on the xz-plane


}
