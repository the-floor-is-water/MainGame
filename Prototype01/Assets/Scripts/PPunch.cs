using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPunch : MonoBehaviour
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
        if (other.tag != "personaje" && other.GetComponentInParent<movimientoProyectil2>() == null && other.GetComponentInParent<movimientoProyectil>() == null)
        {
            Personaje.cicloGolpe = false;
            Personaje.tGolpe = true;
            Personaje.cGolpe = 0;
            Personaje.puedoMovermeGolpe = true;
            Personaje.anim.SetBool("EaglePunch", false);
        }
    }
    private void onTriggerStay(Collider other)
    {
        if (other.tag != "personaje" && other.GetComponentInParent<movimientoProyectil2>() == null && other.GetComponentInParent<movimientoProyectil>() == null)
        {
            Personaje.cicloGolpe = false;
            Personaje.tGolpe = true;
            Personaje.cGolpe = 0;
            Personaje.puedoMovermeGolpe = true;
            Personaje.anim.SetBool("EaglePunch", false);
        }
    }
}
