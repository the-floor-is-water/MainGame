﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingTiles : MonoBehaviour
{
    public Rigidbody rb;
    public float time2fall = 1f;

    float tiempo = 0f;
    public bool playerEntered = false;
    bool tileFalling = false;
    bool restartingPositon = false;
    Vector3 initialPosition;
    Quaternion initialRotation;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        initialPosition = rb.transform.position;
        initialRotation = rb.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.isKinematic && !restartingPositon)
        {
            if (playerEntered)
                tiempo = tiempo + 1 * Time.deltaTime;
            if (tiempo >= time2fall)
            {
                rb.isKinematic = false;
                tileFalling = true;
            }
        }
        else
        {
            if(tileFalling)
            {
                if (rb.transform.position.y <= (initialPosition.y - 15f))
                {
                    restartingPositon = true;
                    rb.useGravity = false;
                    rb.isKinematic = true;
                    tileFalling = false;
                }
            }
            else
            {
                if (rb.transform.position.y <= initialPosition.y)
                    rb.transform.position = new Vector3(rb.transform.position.x, rb.transform.position.y + 0.02f, rb.transform.position.z);
                else
                {
                    rb.transform.rotation = initialRotation;
                    rb.transform.position = initialPosition;
                    restartingPositon = false;
                    playerEntered = false;
                    rb.useGravity = true;
                    tiempo = 0f;
                }    
            }
        }

            
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "personaje" || other.tag == "heavytrow" || other.tag == "dano")
            playerEntered = true;
    }
    void OnTriggerExit(Collider other)
    {
        
    }
}
