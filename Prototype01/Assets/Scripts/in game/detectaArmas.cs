using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class detectaArmas: MonoBehaviour{

// variables de los slot's de armas (los setie alv en el inspector para no hacer mucho pedo):
    public Slot slot;
    public Slot slot2;

    //este slot solo lo pueden cambiar los especiales:
    public Slot slot3;
    
    public Sprite arma;    



    void OnTriggerEnter3D(Collision other) {
    }

    void OnCollisionStay(Collision other) {
    
        Debug.Log("Colision!");
        if(other.gameObject.tag == "Player")
        {
            if(this.gameObject.tag == "Arma")
            {
                Debug.Log("tag del arma es: "+ this.gameObject.tag + ". Tag del Player es: "+ other.gameObject.tag );
                if(this.slot2.estaVacio() && !this.slot.estaVacio())
                {
                    if(!this.slot.getNombre().Equals(this.gameObject.name))
                    {
                        Debug.Log("arma 1 guardada en el slot 2 y arma nueva colocada en slot 1");
                        this.slot2.setItem(this.slot);
                        this.slot.setItem(this.gameObject, this.arma);
                    }
                }
                else if(this.slot2.estaVacio() && this.slot.estaVacio())
                {
                    Debug.Log("arma nueva colocada en el slot 1");
                    this.slot.setItem(this.gameObject, this.arma);
                }
            }

            if(this.gameObject.tag == "Arma_especial")
            {
                Debug.Log("Arma especial guardada en el slot 3");
                this.slot3.setItem(this.gameObject, this.arma);
            }
        }

    }

}