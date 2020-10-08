using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.Rendering;

public class LogicaPies : MonoBehaviour
{
    // Start is called before the first frame update
    public LogicaPersonaje1 logicaPersonaje;
    public float Angulo;
    public Vector3 normal;
    public Vector3 PosicionD;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other) {

        logicaPersonaje.puedoSaltar=true;
         normal = logicaPersonaje.rb.transform.up;
        Vector3 vel = logicaPersonaje.rb.velocity;
        Angulo = Vector3.Angle(vel, -normal);
        logicaPersonaje.Angulo = Angulo;
        bool colina;
        RaycastHit hit;
        Ray ray = new Ray(transform.position,transform.up*-1);

        if (Physics.Raycast(ray, out hit))
        {
            //Debug.Log(hit.normal);
            colina = Vector3.Angle(Vector3.up, hit.normal) >= 30;
            Debug.Log(colina);
            Debug.Log(Vector3.Angle(Vector3.up, hit.normal));
            if (colina)
            {
                float fuerza=2;
                if (Vector3.Angle(Vector3.up, hit.normal) >= 60)
                {
                    fuerza = 2.5f;
                    logicaPersonaje.puedoSaltar = false;
                    logicaPersonaje.anim.SetBool("Slope", true);
                }
                if (Vector3.Angle(Vector3.up, hit.normal) < 60)
                {
                    logicaPersonaje.anim.SetBool("Slope", false);
                }
                logicaPersonaje.rb.AddForce(new Vector3(((1f-hit.normal.y)*hit.normal.x )*fuerza, -.3f,(1f - hit.normal.y) * hit.normal.z) * fuerza, ForceMode.VelocityChange);
            }
        }
      /*  if (Angulo>100)
        {
            PosicionD = other.transform.position;
            var variable = transform.position - PosicionD;

            variable.y = 0;
            logicaPersonaje.rb.AddForce((-variable.normalized) + new Vector3(0, -.3f, 0), ForceMode.VelocityChange);
        }
        if (Angulo < 70 && Angulo !=0)
        {
           PosicionD = other.transform.position;
            var variable = transform.position - PosicionD;

            variable.y = 0;
            logicaPersonaje.rb.AddForce((variable.normalized) + new Vector3(0, -.3f, 0), ForceMode.VelocityChange);
           
        }*/
      

    }
   
    private void OnTriggerExit(Collider other) {
         logicaPersonaje.puedoSaltar=false;
        logicaPersonaje.anim.SetBool("Slope", false);

    }
    
}
