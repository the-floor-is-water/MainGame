using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rollingPrisma : MonoBehaviour
{
    public float movingSpeed = 2f;
    public float rollingSpeed = 4f;
    public bool goingForward = true;

    Vector3 initialPosition;
    float finalPosAdd;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        if (goingForward)
            finalPosAdd = 32f;
        else
            finalPosAdd = -32f;
    }

    // Update is called once per frame
    void Update()
    {
        if (finalPosAdd > 0f)
        {
            if (goingForward)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (movingSpeed * Time.deltaTime));
                transform.Rotate((rollingSpeed * 10) * Time.deltaTime, 0, 0);
                if (transform.position.z >= (initialPosition.z + finalPosAdd))
                    goingForward = false;
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - (movingSpeed * Time.deltaTime));
                transform.Rotate((rollingSpeed * -10) * Time.deltaTime, 0, 0);
                if (transform.position.z <= initialPosition.z)
                    goingForward = true;
            }
        }
        else
        { 
            if (goingForward)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (movingSpeed * Time.deltaTime));
                transform.Rotate((rollingSpeed * 10) * Time.deltaTime, 0, 0);
                if (transform.position.z >= initialPosition.z)
                    goingForward = false;
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - (movingSpeed * Time.deltaTime));
                transform.Rotate((rollingSpeed * -10) * Time.deltaTime, 0, 0);
                if (transform.position.z <= (initialPosition.z + finalPosAdd))
                    goingForward = true;
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

