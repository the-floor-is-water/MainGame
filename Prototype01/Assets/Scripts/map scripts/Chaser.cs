using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    public float chaserSpeed = 1f;

    float velocityAd = 0.1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float rotationVelocity = chaserSpeed * velocityAd;
        transform.Rotate(new Vector3(rotationVelocity, 0f, 0f));
    }
}
