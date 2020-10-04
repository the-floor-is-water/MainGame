using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class movimientoProyectil3 : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocidad;
    public float fireRate;
    public Dano miDanoParado;
    public Dano miDanoAgachado;
    public Vector3 posicion;
    bool choque = false;
    float tiempo;
    float tiempoVida;
    int nChoque = 0;
    Vector3 experimento;
    Rigidbody rb;
    public float bulletForce;
    void Start()
    {
        tiempo = tiempo + 1 * Time.deltaTime;
        tiempoVida = tiempo + 10f;
        rb = this.GetComponent<Rigidbody>();
        //rb.AddForce(rb.transform.forward * velocidad, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {


        transform.localScale += new Vector3(.004f, .004f, .004f);
        velocidad -= .05f;
        tiempo = tiempo + 1 * Time.deltaTime;
        if (velocidad > 0 && !choque)
        {
            transform.position += transform.forward * (velocidad * Time.deltaTime);
        }
        if (tiempoVida < tiempo)
        {
            Destroy(gameObject);
        }


    }
    void OnCollisionEnter(Collision collision)
    {
        //velocidad = 0;

        
        posicion = transform.position;
        choque = true;
        rb.isKinematic = true;
        nChoque += 1;

    }
}
