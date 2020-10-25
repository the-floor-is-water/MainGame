using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    public float xSpeed = 1f;
    float chaserSpeed = 30f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float rotationVelocity = chaserSpeed * xSpeed;
        transform.Rotate(new Vector3(rotationVelocity*Time.deltaTime, 0f, 0f));
    }
}
