using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class fin : MonoBehaviour
{
    /** 
        Checa para que el juego pare como en el pausa debes de llamar este parametro static desde cualquier script donde detectes 
        derrotas, tak que sea así:

        fin.jugadorGanador = 1;

        si es 0 entonces no se dispara, ni siendo menor a 0, ya lo debiste haber notado, siempre requiere de que por lo menos el jugador
        sea un numero mayor a 0.

        ya hace todo lo pertinente para regresar al menu así que solo es detectar.

        Nota: le puse el mismo procedimiento que el cogelamiento de pause, solo que este no se activa con teclas si no que se activa
        con el nomero en jugadorGanador
    */
    public static int jugadorGanador = 0;

    public Text ganador;
    public GameObject menuFin;
    // Start is called before the first frame update
    void Start()
    {
        //esto solo fue para prueba
        //fin.jugadorGanador = 1;
    }

    void Update()
    {
        if(fin.jugadorGanador > 0)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            this.ganador.text = "Jugador #" + fin.jugadorGanador;
            this.menuFin.SetActive( true );
        }
    }

    public void abandonarPartida(){
        Time.timeScale = 1;
        Loader.loadScene("Menu");
    }
}
