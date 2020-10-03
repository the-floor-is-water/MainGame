using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colisionRagdoll : MonoBehaviour
{
    public LogicaPersonaje1 logicaPersonaje;
    public conexionComponentes miConexionComponentes;
    public Vector3 PosicionD;
    public bool suelo;
    public float bulletForce = 20;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = rbRag.position;
        suelo = logicaPersonaje.ragdollSuelo;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag!= "personaje")
        {
            logicaPersonaje.ragdollSuelo = true;
            if (other.gameObject.layer == 12)
            {
                PosicionD = other.GetComponentInParent<movimientoProyectil>().posicion;
                var variable = PosicionD - transform.position ;
                miConexionComponentes.hips.GetComponent<Rigidbody>().AddForce(variable.normalized * bulletForce, ForceMode.VelocityChange);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.tag!= "personaje")
        {
            logicaPersonaje.ragdollSuelo = false;
        }
    }
    void OnCollisionStay(Collision collision)
    {
       /* foreach (ContactPoint contact in collision.contacts)
        {
            print(contact.thisCollider.name + " hit " + contact.otherCollider.name);
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }*/
    }
}
