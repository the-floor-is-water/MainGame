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
            if (other.GetComponentInParent<movimientoProyectil>() != null)
            {
                miConexionComponentes.refrescoCaido = miConexionComponentes.tiempo + 3f;
                /*miConexionComponentes.refrescoCaido = miConexionComponentes.tiempo + 3f;
                PosicionD = other.GetComponentInParent<movimientoProyectil>().posicion;
                var variable = PosicionD - transform.position;
                miConexionComponentes.hips.GetComponent<Rigidbody>().AddForce(variable.normalized * bulletForce, ForceMode.VelocityChange);*/
                PosicionD = other.transform.position;
                var variable = transform.position - PosicionD;
                miConexionComponentes.hips.GetComponent<Rigidbody>().AddForce(variable.normalized * (other.GetComponentInParent<movimientoProyectil>().bulletForce + 30), ForceMode.VelocityChange);
            }
            if (other.GetComponentInParent<movimientoProyectil2>() != null)
            {
                miConexionComponentes.refrescoCaido = miConexionComponentes.tiempo + 3f;
                /*miConexionComponentes.refrescoCaido = miConexionComponentes.tiempo + 3f;
                PosicionD = other.GetComponentInParent<movimientoProyectil2>().posicion;
                var variable = PosicionD - transform.position;
                miConexionComponentes.hips.GetComponent<Rigidbody>().AddForce(variable.normalized * bulletForce, ForceMode.VelocityChange);*/
                PosicionD = other.transform.position;
                var variable = transform.position - PosicionD;
                miConexionComponentes.hips.GetComponent<Rigidbody>().AddForce(variable.normalized * (other.GetComponentInParent<movimientoProyectil2>().bulletForce+30), ForceMode.VelocityChange);
            }
            if (other.GetComponentInParent<movimientoProyectil3>() != null)
            {
                miConexionComponentes.refrescoCaido = miConexionComponentes.tiempo + 3f;
                PosicionD = other.GetComponentInParent<movimientoProyectil3>().posicion;
                var variable = PosicionD - transform.position;
                miConexionComponentes.hips.GetComponent<Rigidbody>().AddForce(variable.normalized * (other.GetComponentInParent<movimientoProyectil3>().bulletForce + 30), ForceMode.VelocityChange);
                /*PosicionD = other.transform.position;
                var variable = transform.position - PosicionD;
                miConexionComponentes.hips.GetComponent<Rigidbody>().AddForce(variable.normalized * other.GetComponentInParent<movimientoProyectil3>().bulletForce, ForceMode.VelocityChange);*/

            }
            if (other.GetComponentInParent<Chaser>() != null)
            {
                PosicionD = other.transform.position;
                var variable = transform.position - PosicionD;
                miConexionComponentes.hips.GetComponent<Rigidbody>().AddForce(((( variable.normalized * 3f))+ new Vector3 (0,5,0)), ForceMode.VelocityChange);
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
