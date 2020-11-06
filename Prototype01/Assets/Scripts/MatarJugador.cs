using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatarJugador : MonoBehaviour
{
    public int stocksJugador1 = 3;
    public int stocksJugador2 = 3;
    public int stocksJugador3 = 3;
    public int stocksJugador4 = 3;
    public int stocksTeclado = 3;
    public GameObject spawnJugador1;
    public GameObject spawnJugador2;
    public GameObject spawnJugador3;
    public GameObject spawnJugador4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent != null)
        {
          
            //Debug.Log(other.transform.parent.name);
            //Desaparicion de jugadores
            if (other.transform.parent.tag == "Jugador1")
            {
                if (stocksJugador1>0)
                {
                    other.transform.position = spawnJugador1.transform.position;
                    stocksJugador1--;
                }
                else
                {
                    other.transform.parent.gameObject.SetActive(false);
                }
                
            }
            if (other.transform.parent.tag == "Jugador2")
            {
                if (stocksJugador2 > 0)
                {
                    other.transform.position = spawnJugador2.transform.position;
                    stocksJugador2--;
                }
                else
                {
                    other.transform.parent.gameObject.SetActive(false);
                }
            }
            if (other.transform.parent.tag == "Jugador3")
            {
                if (stocksJugador3 > 0)
                {
                    other.transform.position = spawnJugador3.transform.position;
                    stocksJugador3--;
                }
                else
                {
                    other.transform.parent.gameObject.SetActive(false);
                }
            }
            if (other.transform.parent.tag == "Jugador4")
            {
                if (stocksJugador4 > 0)
                {
                    other.transform.position = spawnJugador4.transform.position;
                    stocksJugador4--;
                }
                else
                {
                    other.transform.parent.gameObject.SetActive(false);
                }
            }
            if (other.transform.parent.tag == "Teclado")
            {
                if (stocksTeclado > 0)
                {
                    other.transform.position = spawnJugador1.transform.position;
                    stocksTeclado--;
                }
                else
                {
                    other.transform.parent.gameObject.SetActive(false);
                }
            }            
        }
        //Desaparicion de ragdolls
        
        
    }
    

}
