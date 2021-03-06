﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public List<int> layersToIgnore; 
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        foreach( int i in layersToIgnore)
            Physics.IgnoreLayerCollision(this.gameObject.layer, i, true);

        source = GetComponent<AudioSource>();
    }

    void OnMove(Vector2 movementValue)
    {
        movementX = movementValue.x;
        movementY = movementValue.y;

    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PickUp") {
            other.gameObject.SetActive(false);
        }
        Debug.Log("Triggerred " + other.name);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided " + collision.collider.name);
    }
}
