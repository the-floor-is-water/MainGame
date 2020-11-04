using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tilingTiles : MonoBehaviour
{
    public float timer = 4f;
    public bool fallEnabled = true;
    public Rigidbody rb;
    public Material greenM;
    public Material redM;

    float tiempo = 0f;
    bool playerEntered = false;
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
        if (fallEnabled)
            GetComponent<Renderer>().material = redM;
        else
            GetComponent<Renderer>().material = greenM;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (fallEnabled)
        {
            if (tiempo >= timer)
            {
                fallEnabled = false;
                tiempo = 0f;
                GetComponent<Renderer>().material = greenM;
            }
            else
                tiempo = tiempo + 1 * Time.deltaTime;
        }
        else
        {
            if (tiempo >= timer)
            {
                fallEnabled = true;
                tiempo = 0f;
                GetComponent<Renderer>().material = redM;
            }
            else
                tiempo = tiempo + 1 * Time.deltaTime;
        }
        //Debug.Log("Si entra");
        if (rb.isKinematic && !restartingPositon)
        {
            if (playerEntered && fallEnabled)
            {
                rb.isKinematic = false;
                tileFalling = true;
            }
        }
        else
        {
            if (tileFalling)
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
