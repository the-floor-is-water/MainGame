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

    bool playerOn = false;
    float distanceBtw; 
    float distanceL;
    float distanceR;
    int numPlayers = 0;
    List<Collider> colliders = new List<Collider>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(playerOn)
        {
            transform.Rotate(-distanceBtw * constInclination * Time.deltaTime, 0, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            numPlayers++;
            if (!colliders.Contains(other))
                colliders.Add(other);
        }
    }
    void OnTriggerStay(Collider other)
    {
        float auxDs = 0f;
        float auxL;
        float auxR;
        if (other.tag == "Player")
        {
            other.transform.parent.parent.parent = transform;
            playerOn = true;
            if(numPlayers < 2)
            {
                distanceBtw = Vector3.Distance(center.transform.position, other.transform.position);
                distanceL = Vector3.Distance(left.transform.position, other.transform.position);
                distanceR = Vector3.Distance(right.transform.position, other.transform.position);
                if (distanceL < distanceR)
                    distanceBtw = -distanceBtw;
            }
            else
            {
                for(int i = 0; i < numPlayers; i++)
                {
                    auxL = Vector3.Distance(left.transform.position, colliders[i].transform.position);
                    auxR = Vector3.Distance(right.transform.position, colliders[i].transform.position);
                    if (auxL < auxR)
                        auxDs -= Vector3.Distance(center.transform.position, colliders[i].transform.position);
                    else
                        auxDs += Vector3.Distance(center.transform.position, colliders[i].transform.position);
                }
                distanceBtw = auxDs;
            }
            Debug.Log(distanceBtw);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent.parent.parent = null;
            playerOn = false;
            numPlayers--;
            colliders.Remove(other);
        }
    }
}
