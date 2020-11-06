using DynamicRagdoll;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class conexionComponentes : MonoBehaviour
{
    [SerializeField] private GameObject ragdoll;
    [SerializeField] private GameObject animatedM;
    public GameObject hips;
    public GameObject cam1;
    public GameObject cam2;
    public Ragdoll myRag;
    public RagdollController myRagController;
    public LogicaPersonaje1 logicaPer;
    public float refrescoCaido;
    public float tiempo;
    public Controles controles;
    // Start is called before the first frame update
    public bool dead = false;

    void Start()
    {
        ragdoll.gameObject.SetActive(false);
    }
    private void Awake()
    {
        ragdoll.gameObject.SetActive(false);
    }
    public void levantarse()
    {
        animatedM.transform.position = hips.transform.position;
        ragdoll.gameObject.SetActive(false);
        animatedM.gameObject.SetActive(true);
        //nav.enabled = true;
        //myRagController.ragdoll.RepairBones();
        //myRagController.GetUpImmediate();
        myRagController.StartGetUp();

        logicaPer.x = 0;
        logicaPer.y = 0;
        logicaPer.Move();
        logicaPer.puedoMoverme = false;
        logicaPer.anim.SetBool("tocarSuelo", true);
        logicaPer.tGolpe = true;
        logicaPer.cGolpe = 0;
        logicaPer.puedoMovermeGolpe = true;
        logicaPer.anim.SetBool("EaglePunch", false);
    }
    // Update is called once per frame
    void Update()
    {
        tiempo = tiempo + 1 * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.G))
        {

            //hips.transform.position = animatedM.transform.position;
            //hips.transform.position += new Vector3(0, .9f, 0);
            //transform.rotation = animatedM.transform.rotation;

        }




        /*  if (!dead)
          {
              //myRag.gameObject.SetActive(true);
              //myRag.gameObject.SetActive(false);


              myRag.transform.position = animatedM.transform.position;

              //hips.transform.position = animatedM.transform.position;
              //hips.transform.position += new Vector3(0,.9f,0);
              transform.position = animatedM.transform.position;

              transform.rotation = animatedM.transform.rotation;
              //myRagController.GetUpImmediate();

          }*/
        /* 
                if (dead)
                {
                    //myRag.gameObject.SetActive(false);
                    //myRag.gameObject.SetActive(true);

                    myRagController.GoRagdoll("manual");

                    //myRagController.GetUpImmediate();
                    //myRagController.GoRagdoll("manual");
                    animatedM.transform.rotation = transform.rotation;
                    //animatedM.transform.position = myRag.transform.position;
                    animatedM.transform.position = hips.transform.position;

                }*/
        cam2.transform.position = hips.transform.position;
        /*if (logicaPer.tirado && !myRagController.isGettingUp)
        {
            animatedM.transform.position = hips.transform.position;
        }*/
        /* if (Input.GetMouseButton(0))
         {
             float bulletForce = 4;
             RaycastHit hit;
             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             if (Physics.Raycast(ray, out hit))
             {


                 //add force to it's rigidbody
                 hips.GetComponent<Rigidbody>().AddForceAtPosition(ray.direction.normalized * bulletForce / Time.timeScale, hit.point, ForceMode.VelocityChange);
             }
            // hips.GetComponent<Rigidbody>().AddForce(ray.direction.normalized * bulletForce, ForceMode.VelocityChange);
         }   */
        //Funcion para calar daños
       /*if (Input.GetKeyDown(KeyCode.F))
        {
            //toggleDead();
            //myRagController.ragdoll.RepairBones();
            ragdoll.gameObject.SetActive(true);
            animatedM.gameObject.SetActive(false);

            //nav.enabled = false;
            // myRagController.GoRagdoll("manual");
            myRagController.GoRagdoll("");
            logicaPer.tirado = true;
            logicaPer.armaDisparo = false;
            refrescoCaido = tiempo + 4f;
            logicaPer.rb.isKinematic = true;
            logicaPer.rb.isKinematic = false;

        }*/
        if ((controles.aButton || controles.spacebar) && logicaPer.tirado && !myRagController.isGettingUp && logicaPer.ragdollSuelo && refrescoCaido <= tiempo)
        {
            //toggleDead();
            //myRagController.ragdoll.RepairBones();
            //myRagController.StartGetUp();
            animatedM.transform.position = hips.transform.position;
            ragdoll.gameObject.SetActive(false);
            animatedM.gameObject.SetActive(true);
            //nav.enabled = true;
            //myRagController.ragdoll.RepairBones();
            //myRagController.GetUpImmediate();
            myRagController.StartGetUp();

            logicaPer.x = 0;
            logicaPer.y = 0;
            logicaPer.Move();
            logicaPer.puedoMoverme = false;
            logicaPer.anim.SetBool("tocarSuelo", true);
            logicaPer.tGolpe = true;
            logicaPer.cGolpe = 0;
            logicaPer.puedoMovermeGolpe = true;
            logicaPer.anim.SetBool("EaglePunch", false);
            //logicaPer.refrescoLevantarse = logicaPer.setCooldown(2.5f);
        }
    }

   


}
