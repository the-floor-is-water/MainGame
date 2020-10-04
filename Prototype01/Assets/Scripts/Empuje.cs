using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empuje : MonoBehaviour
{
    // Start is called before the first frame update
    public LogicaPersonaje1 Personaje;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
       /* var variable = other.transform.position - transform.position;
        Personaje.rb.AddForce((Personaje.rb.transform.forward*-1) * 20, ForceMode.VelocityChange);*/
    }
}
