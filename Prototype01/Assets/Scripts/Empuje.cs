using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empuje : MonoBehaviour
{
    // Start is called before the first frame update
    public LogicaPersonaje1 Personaje;
    public Vector3 PosicionD;
    public bool empujando = false;
    public float vInicial;
    void Start()
    {
        vInicial = Personaje.velocidadInicial;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
       
        
       
        if (Personaje.puedoSaltar)
        {
            Personaje.anim.SetBool("tocarSuelo", true);
        }

        Personaje.bEmpujado = true;
        PosicionD = other.transform.position;
        var variable =  Personaje.rb.transform.position - PosicionD;
       
        Personaje.puedoCorrer = false;
        Personaje.puedoSaltarChoque = false;
      
            variable.y = 0;
       

        float fuerzaY = 0;
        if (Personaje.puedoSaltar)
        {
            fuerzaY = 0;
        }
        else
        {
            fuerzaY = -.2f;
        }
        if (!Personaje.estoyAgachado)
        {
            Personaje.rb.AddForce(((variable.normalized * 12)) + new Vector3(0, fuerzaY, 0), ForceMode.VelocityChange);
        }
        else
        {
            Personaje.rb.AddForce(((variable.normalized * 24)) + new Vector3(0, fuerzaY, 0), ForceMode.VelocityChange);
        }
       
       

    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        Personaje.bEmpujado = false;
        Personaje.puedoCorrer = true;
        Personaje.puedoSaltarChoque = true;
    }


}
