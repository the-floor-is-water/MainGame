﻿using DynamicRagdoll;
using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using TMPro;
using UnityEngine;

public class LogicaPersonaje1 : MonoBehaviour
{
    public float velocidadMovimiento = 7.0f;
    public float velocidadInicial;
    public float velocidadRotacion = 200f;
    public float velocidadCorriendo;
    public float velocidadAgachado;
    public Animator anim;
    public float x, y;
    public Rigidbody rb;
    public float fuerzaDeSalto = 14f;
    public bool puedoSaltar;
    public bool puedoCorrer;
    public bool puedoSaltarChoque;
    public float fuerzaExtra = 0;
    public CapsuleCollider colParado;
    public CapsuleCollider colAgachado;
    public CapsuleCollider danoParado;
    public CapsuleCollider danoAgachado;
    public GameObject cabeza;
    public LogicaCabeza logicaCabeza;
    public bool estoyAgachado;
    public bool estoyCorriendo;
    public float refrescoCorrer = 0f;
    public float refrescoRevivir = 0f;
    public float refrescoSaltar = 0f;
    public float refrescoAnim = 0f;
    //public float refrescoLevantarse = 0f;
    public float tiempo = 0f;
    public GameObject referencia;
    Vector3 rotationInput = Vector3.zero;
    public bool puedoMoverme = true;
    public bool puedoMovermeGolpe = true;
    public bool tirado = false;
    public bool ragdollSuelo = false;
    public RagdollController myRagController;
    bool dPadLevantado = true;
    public float Angulo;
    public bool armaDisparo = false;
    int dpad = 0;
    bool resetSalte = false;
    public Controles controles;
    public bool bEmpujado = false;
    public CamaraControl cCamara;
    public bool Plataforma = false;
    Quaternion rotacion;
    public int cGolpe=0;
    public bool tGolpe;
    public bool cicloGolpe = false;
    public float tiempoGolpe = 0;
    public GameObject Eagle;
    public GameObject Pistola;
    public GameObject proyectilSpawn;
    public GameObject PistolaRag;
    public GameObject pugilRag;
    public GameObject Spine;
    public GameObject BrazoD;
    public GameObject BrazoDF;
    public GameObject ManoD;
    public GameObject hombroD;
    public GameObject BrazoI;
    public GameObject BrazoIF;
    public GameObject ManoI;
    public GameObject hombroI;
    public GameObject pugil;
    public ControlPlayer controlador;
    public GameObject mira;
    public bool disparar = false;
    public float cLectura = 0;
    public float cSpecial = 0;
    public float cComun = 0;
    public bool tArmaD = false;
    public bool cicloCotonete = false;
    public float posBX=0, posBY=0;
    public bool cicloCotoneter = false;
    public GameObject cotonete;
    Vector3 vVacio = new Vector3(0, 0, 0);
    // Start is called before the first frame update


    void Start()
    {
        rotacion = rb.transform.localRotation;
        anim = GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
        puedoSaltar = false;
        puedoCorrer = true;
        puedoSaltarChoque = true;
        tGolpe = true;
        puedoMovermeGolpe = true;
        velocidadInicial = velocidadMovimiento;
        velocidadAgachado = velocidadMovimiento * .5f;
        velocidadCorriendo = velocidadMovimiento + 2f;
        danoAgachado.enabled = false;
        proyectilSpawn.transform.localScale = new Vector3(0, 0, 0);
        Pistola.transform.localScale = new Vector3(0, 0, 0);
        pugilRag.transform.localScale = new Vector3(0, 0, 0);
        PistolaRag.transform.localScale = new Vector3(0, 0, 0);
        pugil.transform.localScale = new Vector3(0, 0, 0);
        mira.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //----------------------------------------Empuje Parado-----------------------------------------------------------------------------------
        //RaycastHit hit;
       
        /*Vector3 forward = transform.TransformDirection(Vector3.forward);
         Vector3 left = transform.TransformDirection(Vector3.left);
         Vector3 right = transform.TransformDirection(Vector3.right);*/
        //Ray ray = new Ray(transform.position + new Vector3(0,1.1f,0), forward);
        /*Ray ray = new Ray(transform.position + new Vector3(0, .3f, 0), forward);
         Debug.DrawRay(transform.position + new Vector3(0, .5f, 0), forward, Color.blue);
         Debug.DrawRay(transform.position + new Vector3(0, 1.1f, 0), forward, Color.green);
         Debug.DrawRay(transform.position + new Vector3(0, 2.2f, 0), forward, Color.black);
         Debug.DrawRay(transform.position + new Vector3(0, 2.2f, 0), left, Color.black);*/

         /*if (Physics.Raycast(transform.position + new Vector3(0, 1.1f, 0), forward, .4f) && !estoyAgachado)
         {

             Debug.Log("Rayo colisiono");
             rb.AddForce((transform.forward * -1) * 10, ForceMode.Impulse);
            puedoCorrer = false;
           
         }
         if (Physics.Raycast(transform.position + new Vector3(0, 2f, 0), forward, .4f) && !estoyAgachado)
         {

             Debug.Log("Rayo colisiono");
             rb.AddForce((transform.forward * -1) * 10, ForceMode.Impulse);
            puedoCorrer = false;
        }

        if (Physics.Raycast(transform.position + new Vector3(0, 1.1f, 0), forward*-1, .4f) && !estoyAgachado)
        {

            Debug.Log("Rayo colisiono");
            rb.AddForce((transform.forward) * 10, ForceMode.Impulse);
            puedoCorrer = false;
        }
        if (Physics.Raycast(transform.position + new Vector3(0, 2f, 0), forward*-1, .4f) && !estoyAgachado)
        {

            Debug.Log("Rayo colisiono");
            rb.AddForce((transform.forward) * 10, ForceMode.Impulse);
            puedoCorrer = false;
        }

        if (Physics.Raycast(transform.position + new Vector3(0, 1.1f, 0), right, .4f) && !estoyAgachado)
        {

            Debug.Log("Rayo colisiono");
            rb.AddForce((transform.right*-1) * 10, ForceMode.Impulse);
            puedoCorrer = false;
        }
        if (Physics.Raycast(transform.position + new Vector3(0, 2f, 0), right, .4f) && !estoyAgachado)
        {

            Debug.Log("Rayo colisiono");
            rb.AddForce((transform.right*-1) * 10, ForceMode.Impulse);
            puedoCorrer = false;
        }

        if (Physics.Raycast(transform.position + new Vector3(0, 1.1f, 0), left, .4f) && !estoyAgachado)
        {

            Debug.Log("Rayo colisiono");
            rb.AddForce((transform.right) * 10, ForceMode.Impulse);
            puedoCorrer = false;
        }
        if (Physics.Raycast(transform.position + new Vector3(0, 2f, 0), left, .4f) && !estoyAgachado)
        {

            Debug.Log("Rayo colisiono");
            rb.AddForce((transform.right) * 10, ForceMode.Impulse);
            puedoCorrer = false;
        }*/
         //comente hasta aqui --------------------------------------------------------------------------------------------------
        /* RaycastHit hit;

         Vector3 p1 = transform.position + new Vector3(0,1.8f,0);
         float distanceToObstacle = 0;

         // Cast a sphere wrapping character controller 10 meters forward
         // to see if it is about to hit anything.
         if (Physics.SphereCast(p1,1, transform.forward, out hit, .3f))
         {
             distanceToObstacle = hit.distance;
             Debug.Log("Colisiono con " + hit.collider.name);
             rb.AddForce((transform.forward * -1) * 6, ForceMode.Impulse);
         }
         if (Physics.SphereCast(p1,1, transform.right, out hit, .3f))
         {
             distanceToObstacle = hit.distance;
             Debug.Log("Colisiono con " + hit.collider.name);
             rb.AddForce((transform.right * -1) * 6, ForceMode.Impulse);
         }
         if (Physics.SphereCast(p1, 1, transform.right*-1, out hit, .3f))
         {
             distanceToObstacle = hit.distance;
             Debug.Log("Colisiono con " + hit.collider.name);
             rb.AddForce((transform.right) * 6, ForceMode.Impulse);
         }*/


        //---------------------------------------Empuje agachado----------------------------------------------------------------------------------
        /* if (Physics.Raycast(transform.position + new Vector3(0, .5f, 0), forward, .5f) && estoyAgachado)
         {

             Debug.Log("Rayo colisiono");
             rb.AddForce((transform.forward * -1) * 7, ForceMode.Impulse);
         }*/
        //---------------------------------------------------------------------Controles-------------------------------------------------------------------------------------------------------------
        tiempo = tiempo + 1 * Time.deltaTime;
        //Checa si ya paso la animacion de levantarse
        if (!myRagController.isGettingUp)
        {
            puedoMoverme = true;
            tirado = false;
            ragdollSuelo = false;
        }
        //Rotar camara, no se usa pero lo deje por si es util
        /*if (Input.GetMouseButton(1))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * velocidadRotacion, Space.Self);
        }
        if (Input.GetMouseButton(0))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * velocidadRotacion, Space.Self);
        }*/
        //Look();
        if (puedoMoverme && puedoMovermeGolpe)
        {
           
            if ((controles.rTriggerFloat>0 || controles.lClick) && !controlador.slot_1.estaVacio() && cLectura<tiempo && cComun<tiempo)
            {
                cLectura = tiempo + .5f;
                controlador.Accionar = true;
                Wepon item = controlador.slot_1.getItem();
                controlador.usar = item;
                Debug.Log(item.nombre);
                //this.slot_1.usar_arma_o_Item();
            }
            resetSalte = false;
            x = controles.moveHL;
            y = controles.moveVL;
            if (!controles.teclado)
            {
                if (x >= .5 || x <= -.5)
                {
                    x = (float)Math.Round(x);
                }
                if ((x == 1 || x == -1) && (y >= .3 || y <= -.3))
                {
                    y = (float)Math.Round(y);
                }
            }
            anim.SetFloat("VelX", x);
            anim.SetFloat("VelY", y);

            if (controles.dpadVertical == 0 && controles.dpadHorizontal == 0)
            {
                dPadLevantado = true;
            }
            if (controlador.Accionar && cComun < tiempo)
            {
                if (controlador.usar.nombre.Contains("pugil (1)"))
                {

                    cicloCotonete = true;
                    controlador.Accionar = false;
                   
                }
            }
            //Metodo de saltar---------------------------------------------------------------------------------------------------------------------------------------
            if (puedoSaltar && puedoSaltarChoque)
            {
                if (controles.aButton || controles.spacebar && !controles.Ekey && !controles.rightBumper )
                {
                    saltar();
                    resetSalte = true;
                 
                }
                if ((controles.rightBumper || controles.Ekey) && !controlador.slot_3.estaVacio() && !controles.spacebar && !controles.aButton &&  cSpecial<tiempo)
                {
                    
                    Wepon itemc = controlador.slot_3.getItem();
                    cSpecial = tiempo + itemc.cooldown;
                    fuerzaDeSalto = 23;
                        saltar();
                        fuerzaDeSalto = 12;
                        resetSalte = true;
                        controlador.slot_3.usar_arma_o_Item();
                        itemc.isActive = true;
                    
                   
                }
                anim.SetBool("tocarSuelo", true);
            }
            else if(!puedoSaltar)
            {
                estoyCallendo();

            }
            if (!controlador.slot_1.estaVacio())
            {
               
                dPadLevantado = false;
                Wepon itema = controlador.slot_1.getItem();
                controlador.usar = itema;
                if (controlador.usar.nombre.Contains("pugil (1)"))
                {
                   
                    pugil.transform.localScale = new Vector3(1, 1, 1);
                    BrazoD.transform.localRotation = Quaternion.Euler(0, -60, 0);
                    BrazoI.transform.localRotation = Quaternion.Euler(25, 20, 30);
                    BrazoDF.transform.localRotation = Quaternion.Euler(0, -30, 0);
                    BrazoIF.transform.localRotation = Quaternion.Euler(0, 90, -25);
                    ManoD.transform.localRotation = Quaternion.Euler(0,0,0);
                    ManoI.transform.localRotation = Quaternion.Euler(0, 0, 0);
                }
                else if (!controlador.usar.nombre.Contains("pugil (1)") )
                {
                    pugil.transform.localScale = new Vector3(0, 0, 0);
                }

            }
            if (pugil.transform.localScale != vVacio && controlador.slot_1.estaVacio())
            {
                pugil.transform.localScale = new Vector3(0, 0, 0);
            }
            
            //Fin de metodo de saltar---------------------------------------------------------------------------------------------------------------------------------------

            //Metodo de agacharse---------------------------------------------------------------------------------------------------------------------------------------
            if ((controles.leftBumper || controles.lControl) && puedoSaltar)
            {
                agachado(true);
            }
            else
            {
                if (logicaCabeza.contadorDeColision <= 0 && estoyAgachado)
                {
                    agachado(false);
                }
            }
            //Arma disparo---------------------------------------------------------------------------------------------------------------------------------------------------------
            if (!controlador.slot_1.estaVacio())
            {
                dPadLevantado = false;
                Wepon itema = controlador.slot_1.getItem();
                controlador.usar = itema;
                if (    controlador.usar.type == 2)
                {
                    anim.SetBool("armaDisparo", true);
                    tArmaD = true;
                    //armaDisparo = true;
                    Pistola.transform.localScale = new Vector3(1, 1, 1);

                }
                else if(controlador.usar.type != 2 )
                {
                    anim.SetBool("armaDisparo", false);
                    //armaDisparo = false;
                    tArmaD = false;
                    Pistola.transform.localScale = new Vector3(0, 0, 0);
                }

            }
            if (controles.rClick || controles.JLeftB)
            {
                armaDisparo = !armaDisparo;
                mira.SetActive(armaDisparo);
            }
           if (tArmaD && controlador.slot_1.estaVacio())
            {
                anim.SetBool("armaDisparo", false);
                tArmaD = false;
                Pistola.transform.localScale = new Vector3(0, 0, 0);
            }
            
            if (controlador.Accionar)
            {
                if (controlador.usar.type == 2)
                {
                    disparar = true;
                    controlador.Accionar = false;
                }
                
            }
            //Fin de Arma disparo---------------------------------------------------------------------------------------------------------------------------------------------------
            //Fin de metodo de agacharse---------------------------------------------------------------------------------------------------------------------------------------

            //Metodo de correr--------------------------------------------------------------------------------------------------------------------------------------------------
            if ((controles.lTriggerFloat>0 || controles.lShift) && (y == 1 || y == -1 || x == 1 || x == -1) && (refrescoCorrer <= tiempo) && puedoSaltar && puedoCorrer)
            {  
                correr(true);

            }
            else if (estoyCorriendo)
            {
                correr(false);
            }
            //Fin de metodo correr---------------------------------------------------------------------------------------------------------------------------------------
        }
        //Metodo golpear---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        if (controlador.Accionar && cComun<tiempo)
        {
            if (controlador.usar.nombre.Contains("box-gloves (1)"))
            {
               
                cicloGolpe = true;
                controlador.Accionar = false;
            }       
        }
        if (cicloCotonete)
        {
            // Brazo.transform.localRotation = Quaternion.Euler(-35, -50, 0);
            cotonete.SetActive(true);
            cComun = tiempo + controlador.usar.cooldown;
            moverBrazo();
    
        }


    }
    void FixedUpdate()
    {
        //transform.Rotate(0, x * Time.deltaTime * velocidadRotacion,0);
        //transform.Translate(x * Time.deltaTime * velocidadMovimiento, 0, 0);
        //transform.Translate(x * Time.deltaTime * velocidadMovimiento, 0, y * Time.deltaTime * velocidadMovimiento);
        //Move();
        //transform.Rotate(0, x * Time.deltaTime * velocidadRotacion,0);
        //transform.Translate(x * Time.deltaTime * velocidadMovimiento, 0, 0);
        //
        if (bEmpujado)
        {
            transform.Translate(x * Time.deltaTime * velocidadMovimiento*-1, 0, y * Time.deltaTime * velocidadMovimiento*-1);
        }
        else
        {
            transform.Translate(x * Time.deltaTime * velocidadMovimiento, 0, y * Time.deltaTime * velocidadMovimiento);
        }
        //rb.velocity = transform.TransformDirection(x * velocidadMovimiento, rb.velocity.y, y * velocidadMovimiento);
        if (cicloGolpe)
        {
            puedoMovermeGolpe = false;
            if (cGolpe == 0)
            {
                anim.SetBool("EaglePunch", true);
                Eagle.SetActive(true);
                cGolpe = 50;
                tGolpe = false;
                cComun = tiempo + controlador.usar.cooldown;
                controlador.slot_1.usar_arma_o_Item();
            }
            Golpe();
            if (cGolpe != 0)
            {
                cGolpe--;
            }

        }
       
        //Move();

    }
    public void moverBrazo()
    {
        if (!cicloCotoneter)
        {
            hombroD.transform.localRotation = Quaternion.Euler(0, posBY, 0);
            ManoD.transform.localRotation = Quaternion.Euler(0, 0, 0);
            BrazoD.transform.localRotation = Quaternion.Euler(0, posBY, 30);
            
            ManoI.transform.localRotation = Quaternion.Euler(0, 0, 0);
            BrazoI.transform.localRotation = Quaternion.Euler(0, posBY + 40, -posBX + 30);
            //Spine.transform.localRotation = Quaternion.Euler(posBX, 0, 0);
            if (posBX != -50)
            {
                posBX -= 3;
            }
            if (posBY != -90)
            {
                posBY -= 7;
            }

            if (posBX <= -50 && posBY <= -90)
            {
                cicloCotoneter = true;
            }
        }
        else
        {
            hombroD.transform.localRotation = Quaternion.Euler(0, posBY, 0);
            ManoD.transform.localRotation = Quaternion.Euler(0, 0, 0);
            BrazoD.transform.localRotation = Quaternion.Euler(0, posBY, 30);
            
            ManoI.transform.localRotation = Quaternion.Euler(0, 0, 0);
            BrazoI.transform.localRotation = Quaternion.Euler(0, posBY + 40, -posBX + 30);
            //Spine.transform.localRotation = Quaternion.Euler(posBX, 0, 0);
            if (posBX != 0)
            {
                posBX += 3;
            }
            if (posBY != 0)
            {
                posBY += 7;
            }

            if (posBX >= 0 && posBY >= 0)
            {
                posBX = 0;
                posBY = 0;
                cicloCotonete = false;
                cicloCotoneter = false;
                cotonete.SetActive(false);
                
            }
        }
       
    }

    public void saltar()
    {
        anim.SetBool("salte", true);
        rb.AddForce(new Vector3(0, fuerzaDeSalto, 0), ForceMode.Impulse);
        if (puedoSaltar)
        {
            anim.SetBool("salte", false);
        }
    }
    public void agachado(bool agachado)
    {
        //Recibe el parametro true cuando se agacha 
        if (agachado)
        {
            anim.SetBool("agachado", true);
            velocidadMovimiento = velocidadAgachado;
            colAgachado.enabled = true;
            colParado.enabled = false;
            cabeza.SetActive(true);
            estoyAgachado = true;
            danoParado.enabled = false;
            danoAgachado.enabled = true;
        }
        //Recibe el parametro false cuando se deja de agachar
        if (!agachado)
        {
            anim.SetBool("agachado", false);
            velocidadMovimiento = velocidadInicial;
            cabeza.SetActive(false);
            colAgachado.enabled = false;
            colParado.enabled = true;
            estoyAgachado = false;
            danoParado.enabled = true;
            danoAgachado.enabled = false;
        }
    }
    public void correr(bool correr)
    {
        //Recibe el parametro true cuando corre
        if (correr)
        {
            anim.SetBool("correr", true);
            velocidadMovimiento = velocidadCorriendo;
            estoyCorriendo = true;
            if (estoyAgachado)
            {
                velocidadMovimiento *= .5f;
            }
        }
        if (!correr)
        {
            refrescoCorrer = tiempo + .5f;
            anim.SetBool("correr", false);
            estoyCorriendo = false;
            if (!estoyAgachado)
            {
                velocidadMovimiento = velocidadInicial;
            }
        }

    }

    public void estoyCallendo()
    {

        anim.SetBool("tocarSuelo", false);
        anim.SetBool("salte", false);
        rb.AddForce(fuerzaExtra * Physics.gravity * Time.deltaTime);

    }
    public float setCooldown(float tiempoe)
    {
        return tiempo + tiempoe;
    }
    public void Golpe()
    {
        Debug.Log("Estoy golpeando ppro");
        Vector3 adelante = rb.transform.forward;
        adelante.y = 0;
        rb.AddForce(rb.transform.forward * (800 * Time.deltaTime), ForceMode.VelocityChange);
        if (cGolpe==1)
        {
            tGolpe = true;
            cGolpe = 0;
            puedoMovermeGolpe = true;
            Eagle.SetActive(false);
            cicloGolpe = false;
            anim.SetBool("EaglePunch", false);
        }
        //float ultima = tiempo + .4f;
        /*for (int i = 0; i < 200; i++)
        {
            if (tiempo<ultima)
            {
                rb.AddForce(rb.transform.forward * (20 * Time.deltaTime), ForceMode.VelocityChange);
            }
            ultima = tiempo + 2f;
        }*/

    }
        
       
    public void Move()
    {
        Vector3 movement = new Vector3(x, 0, y) * velocidadMovimiento * Time.deltaTime;
        movement = Vector3.ClampMagnitude(movement, 1);
        movement = Vector3.ClampMagnitude(movement, -1);
        Vector3 newPos = rb.position + rb.transform.TransformDirection(movement);
        rb.MovePosition(newPos);
        //Debug.DrawRay(rb.transform.position,newPos,Color.black);

        //Como aplicar una fuerza al personaje
        /*Vector3 movement = new Vector3(x, 0, y);
        Vector3 newPos = rb.transform.TransformDirection(movement);

        //rb.MovePosition(newPos);
        rb.AddForce(newPos * velocidadMovimiento * Time.deltaTime);*/
    }

}
