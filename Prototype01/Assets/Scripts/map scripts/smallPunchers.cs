using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallPunchers : MonoBehaviour
{
    public float xSpeed = 1f;
    public int startDelay = 12;

    int timer = 0;
    float scaleLimit = 5f;
    bool punching = true;
    // Update is called once per frame
    void Update()
    {
        if (timer >= startDelay)
        {
            if (punching)
            {
                if(scaleLimit > transform.localScale.y)
                { 
                    transform.localScale += new Vector3(0, xSpeed * Time.deltaTime, 0);
                }
                else
                {
                    punching = false;
                }
            }
            else 
            {
                if (transform.localScale.y > 1)
                {
                    transform.localScale -= new Vector3(0, xSpeed * Time.deltaTime, 0);
                }
                else
                {
                    punching = true;
                }
                
            }
        }
        else
        {
            timer++;
        }
    }
}
