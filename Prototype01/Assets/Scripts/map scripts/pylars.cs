using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pylars : MonoBehaviour
{
    public Rigidbody rb;
    public bool goingUp = false;
    public float movingSpeed = 2f;

    float velocityAd = 0.01f;
    Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        initialPosition = rb.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float ms = movingSpeed * velocityAd;
        if (goingUp)
        {
            rb.transform.position = new Vector3(rb.transform.position.x, rb.transform.position.y + ms, rb.transform.position.z);
            if (rb.transform.position.y >= initialPosition.y)
                goingUp = false;
        }
        else
        {
            rb.transform.position = new Vector3(rb.transform.position.x, rb.transform.position.y - ms, rb.transform.position.z);
            if (rb.transform.position.y <= (initialPosition.y - 10f))
                goingUp = true;
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
