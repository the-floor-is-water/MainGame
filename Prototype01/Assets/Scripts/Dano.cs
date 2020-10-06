using DynamicRagdoll;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dano : MonoBehaviour
{
    public LogicaPersonaje1 logicaPer;
    public conexionComponentes miConexionComponentes;
    public RagdollController myRagController;
    [SerializeField] private GameObject ragdoll;
    [SerializeField] private GameObject animatedM;
    public float Angulo;
    public LogicaCabeza miCabeza;
    public bool golpeado = false;
    public Vector3 PosicionD;
    public float bulletForce = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "dano" && !logicaPer.tirado)
        {
            ragdoll.gameObject.SetActive(true);
            animatedM.gameObject.SetActive(false);
            //nav.enabled = false;
            // myRagController.GoRagdoll("manual");
            myRagController.GoRagdoll("");
            logicaPer.tirado = true;
            logicaPer.armaDisparo = false;
            logicaPer.rb.isKinematic = true;
            logicaPer.rb.isKinematic = false;
            miConexionComponentes.refrescoCaido = miConexionComponentes.tiempo + 4f;
            miCabeza.contadorDeColision = 0;
            if (other.GetComponentInParent<movimientoProyectil>() != null)
            {
                /*PosicionD = other.GetComponentInParent<movimientoProyectil>().posicion;
                var variable = PosicionD -transform.position;
                miConexionComponentes.hips.GetComponent<Rigidbody>().AddForce(variable.normalized * bulletForce, ForceMode.VelocityChange);*/
                PosicionD = other.transform.position;
                var variable = transform.position - PosicionD;
                miConexionComponentes.hips.GetComponent<Rigidbody>().AddForce((variable.normalized * other.GetComponentInParent<movimientoProyectil>().bulletForce) + new Vector3(0, 10, 0), ForceMode.VelocityChange);
            }
            if (other.GetComponentInParent<movimientoProyectil2>() != null)
            {
                /*PosicionD = other.GetComponentInParent<movimientoProyectil2>().posicion;
                var variable = PosicionD - transform.position;
                miConexionComponentes.hips.GetComponent<Rigidbody>().AddForce(variable.normalized * bulletForce, ForceMode.VelocityChange);*/
                PosicionD = other.transform.position;
                var variable = transform.position - PosicionD;
                miConexionComponentes.hips.GetComponent<Rigidbody>().AddForce((variable.normalized * other.GetComponentInParent<movimientoProyectil2>().bulletForce) + new Vector3(0, 10, 0), ForceMode.VelocityChange);
            }
            if (other.GetComponentInParent<movimientoProyectil3>() != null)
            {
                PosicionD = other.transform.position;
                var variable = PosicionD - transform.position;
                miConexionComponentes.hips.GetComponent<Rigidbody>().AddForce(variable.normalized * other.GetComponentInParent<movimientoProyectil3>().bulletForce, ForceMode.VelocityChange);
                /*PosicionD = other.transform.position;
                var variable = transform.position - PosicionD;
                miConexionComponentes.hips.GetComponent<Rigidbody>().AddForce(variable.normalized * other.GetComponentInParent<movimientoProyectil3>().bulletForce, ForceMode.VelocityChange);*/
            }
            if (other.GetComponentInParent<Chaser>() != null)
            {
                PosicionD = other.transform.position;
                var variable = transform.position - PosicionD;
                miConexionComponentes.hips.GetComponent<Rigidbody>().AddForce((((variable.normalized * 3f)) + new Vector3(0, 5, 0)), ForceMode.VelocityChange);
            }

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        /* measure angle
        if (Vector3.Angle(vel, -normal) > 20)
        {
            // bullet bounces off the surface
            logicaPersonaje.rb.velocity = Vector3.Reflect(vel, normal *500);
        }*/
    }
}
