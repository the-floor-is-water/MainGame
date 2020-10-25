using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator : MonoBehaviour
{
    public bool goingUp = false;
    public float movingSpeed = 2f;

    Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        float ms = movingSpeed * Time.deltaTime;
        if (goingUp)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + ms, transform.position.z);
            if (transform.position.y >= initialPosition.y)
                goingUp = false;
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - ms, transform.position.z);
            if (transform.position.y <= (initialPosition.y - 8f))
                goingUp = true;
        }
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
