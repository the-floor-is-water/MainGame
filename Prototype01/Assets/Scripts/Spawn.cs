using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    // Start is called before the first frame update
    //Conexion de personajes y camaras
    public GameObject jugador1;
    public GameObject jugador2;
    public GameObject jugador3;
    public GameObject jugador4;
    public Camera camara1;
    public Camera camara2;
    public Camera camara3;
    public Camera camara4;

    void Start()
    {
        if (Config.configuraciones.numeroJugadores == 2)
        {
            jugador3.SetActive(false);
            jugador4.SetActive(false);
            jugador1.SetActive(true);
            camara1.rect = new Rect(0, .5f, 1, 1);
            jugador2.SetActive(true);
            camara2.rect = new Rect(0, -.5f, 1, 1);
        }
        if (Config.configuraciones.numeroJugadores == 3)
        {
            jugador4.SetActive(false);
            jugador1.SetActive(true);
            camara1.rect = new Rect(-.5f, .5f, 1, 1);
            jugador2.SetActive(true);
            camara2.rect = new Rect(.5f, .5f, 1, 1);
            jugador3.SetActive(true);
            camara3.rect = new Rect(-.5f, -.5f, 1, 1);
        }
        if (Config.configuraciones.numeroJugadores == 4)
        {
            jugador1.SetActive(true);
            camara1.rect = new Rect(-.5f, .5f, 1, 1);
            jugador2.SetActive(true);
            camara2.rect = new Rect(.5f, .5f, 1, 1);
            jugador3.SetActive(true);
            camara3.rect = new Rect(-.5f, -.5f, 1, 1);
            jugador4.SetActive(true);
            camara4.rect = new Rect(.5f, -.5f, 1, 1);
        }
        }

    // Update is called once per frame
    void Update()
    {
        
    }
}
