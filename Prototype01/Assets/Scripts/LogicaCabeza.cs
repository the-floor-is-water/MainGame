using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaCabeza : MonoBehaviour
{
    public int contadorDeColision=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter(Collider other) {
        contadorDeColision = 1;
    }
     void OnTriggerExit(Collider other) {
        contadorDeColision = 0;
    }

}
