using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingArch : MonoBehaviour
{
    public Rigidbody rb;
    public float movingSpeed = 2f;
    public float spinningSpeed = 4f;
    public bool goingForward = true;


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
        float ss = spinningSpeed * velocityAd;
        if (goingForward)
        {
            rb.transform.position = new Vector3(rb.transform.position.x + ms, rb.transform.position.y, rb.transform.position.z);
            transform.Rotate(0, 50 * Time.deltaTime, 0);
            if (rb.transform.position.x >= (initialPosition.x + 15f))
                goingForward = false;
        }
        else
        {
            rb.transform.position = new Vector3(rb.transform.position.x - ms, rb.transform.position.y, rb.transform.position.z);
            transform.Rotate(0, 50 * Time.deltaTime, 0);
            if (rb.transform.position.x <= initialPosition.x)
                goingForward = true;
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
