using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class cylinderRotation : MonoBehaviour
{
    public float velocity = 1f;


    float velocityAd = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float rotationVelocity = velocity * velocityAd;
        transform.Rotate(new Vector3(0f, rotationVelocity, 0f));
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
            other.transform.parent.parent.parent = transform;
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            other.transform.parent.parent.parent = null;
    }
}
