using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vidas : MonoBehaviour
{
    // Start is called before the first frame update
    public Text vidas;
    public MatarJugador matador;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent.parent.parent.tag=="Teclado")
        {
            vidas.text = "x" + matador.stocksTeclado;
        }
        if (transform.parent.parent.parent.tag == "Jugador1")
        {
            vidas.text = "x" + matador.stocksJugador1;
        }
        if (transform.parent.parent.parent.tag == "Jugador2")
        {
            vidas.text = "x" + matador.stocksJugador2;
        }
        if (transform.parent.parent.parent.tag == "Jugador3")
        {
            vidas.text = "x" + matador.stocksJugador3;
        }
        if (transform.parent.parent.parent.tag == "Jugador4")
        {
            vidas.text = "x" + matador.stocksJugador4;
        }

    }
}
