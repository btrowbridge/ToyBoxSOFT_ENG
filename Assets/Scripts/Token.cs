using UnityEngine;
using System.Collections;

public class Token : Collectable {

    public static int scoreValue = 1;
    public int rotateSpeed = 90;
	// Use this for initialization
	void Start () {
	    
	}

    // Update is called once per frame
    void Update () {
        gameObject.transform.RotateAround(transform.position, Vector3.up, Time.deltaTime * rotateSpeed);
	}
}
