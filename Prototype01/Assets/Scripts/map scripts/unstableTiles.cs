using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unstableTiles : MonoBehaviour
{
    public Rigidbody rb;
    public float time2fall = 5f;

    float tiempo = 0f;
    public bool playerEntered = false;
    bool tileFalling = false;
    bool restartingPositon = false;
    Vector3 initialPosition;
    Quaternion initialRotation;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (!tileFalling && !restartingPositon)
        {
            if (playerEntered)
                tiempo = tiempo + 1 * Time.deltaTime;
            if (tiempo >= time2fall)
            {
                tileFalling = true;
            }
        }
        else
        {
            if (tileFalling)
            {
                transform.Rotate(0, 0, -60 * Time.deltaTime);
                if (transform.rotation.eulerAngles.z <= 270)
                {
                    restartingPositon = true;
                    tileFalling = false;
                }
            }
            else
            {
                //Debug.Log(transform.rotation.eulerAngles.z);
                if (transform.rotation.eulerAngles.z > 250)
                    transform.Rotate(0, 0, 50 * Time.deltaTime);
                else
                {
                    transform.rotation = initialRotation;
                    transform.position = initialPosition;
                    restartingPositon = false;
                    playerEntered = false;
                    tiempo = 0f;
                }
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "personaje" || other.tag == "heavytrow" || other.tag == "dano")
            playerEntered = true;
    }
    void OnTriggerExit(Collider other)
    {

    }
}
