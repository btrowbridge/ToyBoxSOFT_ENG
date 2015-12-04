using UnityEngine;
using System.Collections;



public abstract class Collectable : MonoBehaviour
{
    public Player player;
    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<Player>();
    }
    void OnTriggerEnter(Collider other) { 
		if (other.gameObject.GetComponent<Player>())
			gameObject.SetActive (false);
	}

    // Update is called once per frame
    void Update()
    {

    }
}
