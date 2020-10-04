using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class punchBlocks : MonoBehaviour
{
    public Rigidbody rb;
    public float movingSpeed = 2f;
    public bool paused = true;
    public float timer = 3f;


    float velocityAd = 0.01f;
    Vector3 initialPosition;
    bool goingForward = true;
    float tiempo = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        initialPosition = rb.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float ms = movingSpeed * velocityAd;
        if (paused)
        {
            if (tiempo >= timer)
            {
                paused = false;
                tiempo = 0f;
            }
            else
                tiempo = tiempo + 1 * Time.deltaTime;
        }
        else 
        { 
            if (goingForward)
            {
                rb.transform.position = new Vector3(rb.transform.position.x, rb.transform.position.y, rb.transform.position.z - ms);
                if (rb.transform.position.z <= (initialPosition.z - 20f))
                    goingForward = false;
            }
            else
            {
                rb.transform.position = new Vector3(rb.transform.position.x, rb.transform.position.y, rb.transform.position.z + ms);
                if (rb.transform.position.z >= initialPosition.z)
                {
                    paused = true;
                    goingForward = true;
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            other.transform.parent.parent.parent = transform;
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            other.transform.parent.parent.parent = null;
    }
}
