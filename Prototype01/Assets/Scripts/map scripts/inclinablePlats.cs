using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inclinablePlats : MonoBehaviour
{
    public float constInclination = 5f;
    public float limitInclination = 70f;
    public GameObject center;
    public GameObject left;
    public GameObject right;

    float totalInclination = 0f;
    bool playerOn = false;
    float distanceBtw; 
    float distanceL;
    float distanceR;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(playerOn && transform.rotation.x < limitInclination)
        {
            transform.Rotate(-distanceBtw * constInclination * Time.deltaTime, 0, 0);
            totalInclination += -distanceBtw * constInclination * Time.deltaTime;
        }
    }

    /*void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
        }
    }*/
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent.parent.parent = transform;
            playerOn = true;
            distanceBtw = Vector3.Distance(center.transform.position, other.transform.position);
            distanceL = Vector3.Distance(left.transform.position, other.transform.position);
            distanceR = Vector3.Distance(right.transform.position, other.transform.position);
            if (distanceL < distanceR)
                distanceBtw = -distanceBtw;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent.parent.parent = null;
            playerOn = false;
        }
    }
}
