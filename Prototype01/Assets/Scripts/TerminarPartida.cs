using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminarPartida : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera aux;
    public string Ganador;
    public List<GameObject> LJugadores = new List<GameObject>();
    public int cActivos=0;
    bool activar = true;
    public Camera camara1;
    public Camera camara2;
    public Camera camara3;
    public Camera camara4;
    void Start()
    {
        cActivos = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cActivos = 0;
        foreach (var item in LJugadores)
        {
            if (item.activeSelf)
            {
                cActivos++;
            }
        }
        if (cActivos == 1 && activar)
        {
            foreach (var item in LJugadores)
            {
                if (item.activeSelf)
                {
                    Ganador = item.tag;
                    Debug.Log(Ganador);
                }
            }
            camara1.rect = new Rect(0, 0, 1, 1);
            camara2.rect = new Rect(0, 0, 1, 1);
            camara3.rect = new Rect(0, 0, 1, 1);
            camara4.rect = new Rect(0, 0, 1, 1);
            if (Ganador=="Jugador1")
            {
                fin.jugadorGanador = 1;
            }
            if (Ganador == "Jugador2")
            {
                fin.jugadorGanador = 2;
            }
            if (Ganador == "Jugador3")
            {
                fin.jugadorGanador = 3;
            }
            if (Ganador == "Jugador4")
            {
                fin.jugadorGanador = 4;
            }
            if (Ganador == "Teclado")
            {
                fin.jugadorGanador = 5;
            }
            activar = false;
        }
        if (cActivos == 0 )
        {
            aux.gameObject.SetActive(true);
        }
        if (cActivos == 0 && activar)
        {
            aux.gameObject.SetActive(true);
            fin.jugadorGanador = 6;
            activar = false;
        }
        
    }
}
