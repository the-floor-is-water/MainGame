using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionProyectil3 : MonoBehaviour
{
    // Start is called before the first frame update
    float tiempo = 0;
    bool crecer = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tiempo = tiempo + 1 * Time.deltaTime;
        if (tiempo >= 2)
        {
            tiempo = 0;
            crecer = !crecer;
        }
        if (crecer)
        {
            transform.localScale += new Vector3(.004f, .004f, .004f);
        }
        else
        {
            transform.localScale -= new Vector3(.004f, .004f, .004f);
        }
        
        
    }
}
