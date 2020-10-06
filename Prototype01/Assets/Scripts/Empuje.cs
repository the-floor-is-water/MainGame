using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empuje : MonoBehaviour
{
    // Start is called before the first frame update
    public LogicaPersonaje1 Personaje;
    public Vector3 PosicionD;
    void Start()
    {
        
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
        PosicionD = other.transform.position;
        var variable = PosicionD - transform.position;
        variable.y = 0;
        Personaje.puedoCorrer = false;
        Personaje.puedoSaltarChoque = false;
        Personaje.rb.AddForce(((variable.normalized * 2)*-1) + new  Vector3(0,-.2f,0), ForceMode.Impulse);

    }
    private void OnTriggerExit(Collider other)
    {
        Personaje.puedoCorrer = true;
        Personaje.puedoSaltarChoque = true;
    }


}
