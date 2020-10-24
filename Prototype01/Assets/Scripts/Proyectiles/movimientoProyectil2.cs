using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoProyectil2 : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocidad;
    public float fireRate;
    public Vector3 posicion;
    float tiempo;
    float tiempoVida;
    int nChoque = 0;
    Vector3 experimento;
    Rigidbody rb;
    public float bulletForce;
    public Vector3 adelante;
    void Start()
    {
        tiempo = tiempo + 1 * Time.deltaTime;
        tiempoVida = tiempo + 10;
        rb = this.GetComponent<Rigidbody>();
        rb.AddForce(rb.transform.forward * velocidad, ForceMode.Impulse);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tiempo = tiempo + 1 * Time.deltaTime;
        if (tiempoVida < tiempo)
        {
            Destroy(gameObject);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<fallingTiles>() != null)
        {
            collision.gameObject.GetComponent<fallingTiles>().playerEntered = true;
        }
        posicion = rb.transform.position;
        adelante = transform.position - collision.transform.position;
        rb.AddForce(rb.transform.forward * velocidad, ForceMode.Acceleration);
    }
}
