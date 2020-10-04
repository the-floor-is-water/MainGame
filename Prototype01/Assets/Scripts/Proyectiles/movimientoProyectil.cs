using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class movimientoProyectil : MonoBehaviour
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
        /*rb = this.GetComponent<Rigidbody>();
        rb.AddForce(rb.transform.forward * velocidad, ForceMode.Impulse);*/
    }

    // Update is called once per frame
    void Update()
    {
        
        
        transform.localScale += new Vector3(.003f, .003f, .003f);
        velocidad -= .05f;
        tiempo = tiempo + 1 * Time.deltaTime;
        if (velocidad>0 && !choque)
        {
            transform.position += transform.forward * (velocidad * Time.deltaTime);
        }
        if(choque && velocidad>0)
        {
            transform.position -= transform.forward * (velocidad * Time.deltaTime);
        }
        if (tiempoVida<tiempo || nChoque>=4)
        {
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("No hay velocidad");
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        //velocidad = 0;
        
           if (collision.gameObject.GetComponent<fallingTiles>()!=null)
            {
                collision.gameObject.GetComponent<fallingTiles>().playerEntered = true;
            }
        posicion = transform.position;
        choque = !choque;
        nChoque += 1;
        Debug.Log("Colisiono");

    }
}
