using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seasick : MonoBehaviour
{
    public float rotorSpeed = 5f;

    float velocityAd = 0.1f;
    float rotationVelocity = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rotationVelocity = rotorSpeed * velocityAd;
        transform.Rotate(new Vector3(0f, rotationVelocity, 0f));
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent.parent.parent = transform;
        }
            
           
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent.parent.parent = null;
        }
            
       
    }
}
