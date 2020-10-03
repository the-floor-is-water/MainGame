using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoProyectil : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocidad;
    public float fireRate;
    public Dano miDanoParado;
    public Dano miDanoAgachado;
    public Vector3 posicion;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (velocidad!=0)
        {
            transform.position += transform.forward * (velocidad * Time.deltaTime);
        }
        else
        {
            Debug.Log("No hay velocidad");
        }
    }
     void OnCollisionEnter(Collision collision)
    {
        //velocidad = 0;
        collision.gameObject.GetComponent<fallingTiles>().playerEntered = true;
        posicion = transform.position;
        Destroy(gameObject);
        Debug.Log("Colisiono");
    }
}
