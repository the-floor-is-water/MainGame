using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatarJugador : MonoBehaviour
{
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
                other.transform.parent.gameObject.SetActive(false);
            }
            if (other.transform.parent.tag == "Jugador2")
            {
                other.transform.parent.gameObject.SetActive(false);
            }
            if (other.transform.parent.tag == "Jugador3")
            {
                other.transform.parent.gameObject.SetActive(false);
            }
            if (other.transform.parent.tag == "Jugador4")
            {
                other.transform.parent.gameObject.SetActive(false);
            }
            if (other.transform.parent.tag == "Teclado")
            {
                other.transform.parent.gameObject.SetActive(false);
            }            
        }
        //Desaparicion de ragdolls
        
        
    }
    private void OnTriggerStay(Collider other)
    {

        if (other.transform.parent != null)
        {
            
            //Debug.Log(other.transform.parent.name);
            //Desaparicion de jugadores
            if (other.transform.parent.tag == "Jugador1")
            {
                other.transform.parent.gameObject.SetActive(false);
            }
            if (other.transform.parent.tag == "Jugador2")
            {
                other.transform.parent.gameObject.SetActive(false);
            }
            if (other.transform.parent.tag == "Jugador3")
            {
                other.transform.parent.gameObject.SetActive(false);
            }
            if (other.transform.parent.tag == "Jugador4")
            {
                other.transform.parent.gameObject.SetActive(false);
            }
            if (other.transform.parent.tag == "Teclado")
            {
                other.transform.parent.gameObject.SetActive(false);
            }
        }
        //Desaparicion de ragdolls
        
    }
}
