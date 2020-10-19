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
            if (logicaPer.tGolpe || other.GetComponentInParent<Chaser>() != null || other.GetComponentInParent<movimientoProyectil3>() != null || other.GetComponentInParent<EaglePunch>() != null)
            {
                ragdoll.gameObject.SetActive(true);
                animatedM.gameObject.SetActive(false);
                //nav.enabled = false;
                // myRagController.GoRagdoll("manual");
                myRagController.GoRagdoll("");
                logicaPer.tirado = true;
                logicaPer.armaDisparo = false;
                logicaPer.mira.SetActive(false);
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
                    variable.y = 0;
                    miConexionComponentes.hips.GetComponent<Rigidbody>().AddForce((variable.normalized * (other.GetComponentInParent<movimientoProyectil>().bulletForce + 10)) + new Vector3(0, 10, 0), ForceMode.VelocityChange);
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
                    logicaPer.cicloGolpe = false;
                    logicaPer.tGolpe = true;
                    logicaPer.cGolpe = 0;
                    logicaPer.anim.SetBool("EaglePunch", false);
                    PosicionD = other.transform.position;
                    var variable = PosicionD - transform.position;
                    miConexionComponentes.hips.GetComponent<Rigidbody>().AddForce(variable.normalized * other.GetComponentInParent<movimientoProyectil3>().bulletForce, ForceMode.VelocityChange);
                    /*PosicionD = other.transform.position;
                    var variable = transform.position - PosicionD;
                    miConexionComponentes.hips.GetComponent<Rigidbody>().AddForce(variable.normalized * other.GetComponentInParent<movimientoProyectil3>().bulletForce, ForceMode.VelocityChange);*/
                }
                if (other.GetComponentInParent<Chaser>() != null)
                {
                    logicaPer.cicloGolpe = false;
                    logicaPer.tGolpe = true;
                    logicaPer.cGolpe = 0;
                    logicaPer.anim.SetBool("EaglePunch", false);
                    PosicionD = other.transform.position;
                    var variable = transform.position - PosicionD;
                    miConexionComponentes.hips.GetComponent<Rigidbody>().AddForce((((variable.normalized * 3f)) + new Vector3(0, 5, 0)), ForceMode.VelocityChange);
                }
                if (other.GetComponentInParent<EaglePunch>() != null)
                {
                    logicaPer.cicloGolpe = false;
                    logicaPer.tGolpe = true;
                    logicaPer.cGolpe = 0;
                    logicaPer.anim.SetBool("EaglePunch", false);
                    PosicionD = other.transform.position;
                    var variable = transform.position - PosicionD;
                    variable.y = 0;
                    miConexionComponentes.hips.GetComponent<Rigidbody>().AddForce((((variable.normalized * 20f)) + new Vector3(0, 3, 0)), ForceMode.VelocityChange);
                }
            }
           
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponentInParent<movimientoProyectil3>() != null)
        {
            PosicionD = other.transform.position;
            var variable = PosicionD - transform.position;
            miConexionComponentes.hips.GetComponent<Rigidbody>().AddForce(variable.normalized * other.GetComponentInParent<movimientoProyectil3>().bulletForce, ForceMode.VelocityChange);
            /*PosicionD = other.transform.position;
            var variable = transform.position - PosicionD;
            miConexionComponentes.hips.GetComponent<Rigidbody>().AddForce(variable.normalized * other.GetComponentInParent<movimientoProyectil3>().bulletForce, ForceMode.VelocityChange);*/
        }
        /* measure angle
        if (Vector3.Angle(vel, -normal) > 20)
        {
            // bullet bounces off the surface
            logicaPersonaje.rb.velocity = Vector3.Reflect(vel, normal *500);
        }*/
    }
}
