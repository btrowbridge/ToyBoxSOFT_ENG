using UnityEngine;
using System.Collections;

public class CubeManager : MonoBehaviour {


    private bool rotating;

    public bool up, down, left, right = false;	//Flags for cube movement
	
    public float degrees;
    public float rotateTime;

    public GameObject ghostBox;
	public GameObject triggerWalls; // reference to trigger walls
	public GameObject player;		//reference to player object
    
   
   
                                // Use this for initialization
    void Start () {
		//find referenced objects in game scene
		triggerWalls = GameObject.FindGameObjectWithTag ("TriggerWalls");
		player = GameObject.FindGameObjectWithTag ("Player");
        

    }

    // Update is called once per frame
    void Update () {

    }
    public IEnumerator rotate(Transform target) {
        //testing another algorithm
        if (rotating) { yield break; }
        rotating = true;

        //Decide which axis to rotate
        Vector3 rotateAxis = Vector3.up;
        if (up) { rotateAxis = Vector3.left; }
        else if (down) { rotateAxis = Vector3.right; }
        else if (left) { rotateAxis = Vector3.back; }
        else if (right) { rotateAxis = Vector3.forward; }

        var otherTransform = target.transform;
        var startRotation = transform.rotation;
        var startPosition = transform.position;
        transform.RotateAround(otherTransform.position, rotateAxis, degrees);
        var endRotation = transform.rotation;
        var endPosition = transform.position;
        transform.rotation = startRotation;
        transform.position = startPosition;

        var rate = degrees / rotateTime;
        for (float i = 0.0f; i < degrees; i += Time.deltaTime * rate)
        {
            yield return 0;
            transform.RotateAround(otherTransform.position, rotateAxis, Time.deltaTime * rate);
        }

        transform.rotation = endRotation;
        transform.position = endPosition;
        rotating = false;
     
        Stop();
    }
    //when stopping adjust the trigger wall
    void Stop() {
        UnityEngine.Debug.Log("Box should stop");
        triggerWalls.transform.position = transform.position;
        /*
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
            */
            up = false;
            down = false;
            left = false;
            right = false;
        
    }
    //if square is under the player, stop all movement
	//Note: the player objects orientation will be frozen on the xz-plane


}
