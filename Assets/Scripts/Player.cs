using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Ball;

public class Player : Ball {

    private int score;
    private int health = 10;

    public GameObject square;
    

    public void addScore() {}
    public int getScore() { return score; }
    public void resetScore() {}

    public void takeDamage() {}
    public int getHealth() { return health; }
    public void setHealth(int value) {}

    public void OnTriggerExit(Collider other) { }
    public void OnTrigerEnter(Collider other) { }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
