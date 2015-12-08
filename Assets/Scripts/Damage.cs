using UnityEngine;
using System.Collections;


public class Damage : Collectable {

    public static int damageValue = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.rotation = Random.rotationUniform;
	}
}
