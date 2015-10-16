﻿using UnityEngine;
using System.Collections;



public abstract class Collectable : MonoBehaviour
{
    public Player player;
    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<Player>();
    }
    void OnTriggerEnter(Collider other) { }

    // Update is called once per frame
    void Update()
    {

    }
}