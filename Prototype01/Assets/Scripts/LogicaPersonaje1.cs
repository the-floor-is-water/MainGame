using DynamicRagdoll;
using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
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
    public float refrescoAnim = 0f;
    //public float refrescoLevantarse = 0f;
    public float tiempo = 0f;
    public GameObject referencia;
    Vector3 rotationInput = Vector3.zero;
    public bool puedoMoverme = true;
    public bool tirado = false;
    public bool ragdollSuelo = false;
    public RagdollController myRagController;
    bool dPadLevantado = true;
    public float Angulo;
    public bool armaDisparo = false;
    int dpad = 0;
    public Controles controles;
    // Start is called before the first frame update


    void Start()
    {
        anim = GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
        puedoSaltar = false;
        velocidadInicial = velocidadMovimiento;
        velocidadAgachado = velocidadMovimiento * .5f;
        velocidadCorriendo = velocidadMovimiento + 2f;
        danoAgachado.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
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

        if (puedoMoverme)
        {


            x = controles.moveHL;
            y = controles.moveVL;
            if (x >= .5 || x <= -.5)
            {
                x = (float)Math.Round(x);
            }
            if ((x == 1 || x == -1) && (y >= .3 || y <= -.3))
            {
                y = (float)Math.Round(y);
            }
            anim.SetFloat("VelX", x);
            anim.SetFloat("VelY", y);

            if (controles.dpadVertical == 0 && controles.dpadHorizontal == 0)
            {
                dPadLevantado = true;
            }
            //Metodo de saltar---------------------------------------------------------------------------------------------------------------------------------------
            if (puedoSaltar)
            {

                if (controles.aButton)
                {
                    saltar();
                }
                anim.SetBool("tocarSuelo", true);
            }
            else
            {

                estoyCallendo();


            }
            //Fin de metodo de saltar---------------------------------------------------------------------------------------------------------------------------------------

            //Metodo de agacharse---------------------------------------------------------------------------------------------------------------------------------------
            if (controles.rightBumper && puedoSaltar)
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
            if (controles.dpadVertical == 1 && dPadLevantado)
            {
                dPadLevantado = false;

                if (!armaDisparo)
                {
                    anim.SetBool("armaDisparo", true);
                    armaDisparo = true;
                }
                else
                {
                    anim.SetBool("armaDisparo", false);
                    armaDisparo = false;
                }

            }
            //Fin de Arma disparo---------------------------------------------------------------------------------------------------------------------------------------------------
            //Fin de metodo de agacharse---------------------------------------------------------------------------------------------------------------------------------------

            //Metodo de correr--------------------------------------------------------------------------------------------------------------------------------------------------
            if (controles.leftBumper && (y == 1 || y == -1 || x == 1 || x == -1) && (refrescoCorrer <= tiempo) && puedoSaltar)
            {
                correr(true);
            }
            else if (estoyCorriendo)
            {
                correr(false);
            }
            //Fin de metodo correr---------------------------------------------------------------------------------------------------------------------------------------
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
        transform.Translate(x * Time.deltaTime * velocidadMovimiento, 0, y * Time.deltaTime * velocidadMovimiento);
        //Move();

    }
    public void saltar()
    {
        anim.SetBool("salte", true);
        rb.AddForce(new Vector3(0, fuerzaDeSalto, 0), ForceMode.Impulse);
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
