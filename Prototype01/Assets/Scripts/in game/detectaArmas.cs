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
    
        if(this.gameObject.tag == "Arma")
        {
            if(this.slot2.estaVacio() && !this.slot.estaVacio())
            {
                if(!this.slot.getNombre().Equals(this.gameObject.name))
                {
                    this.slot2.setItem(this.slot);
                    this.slot.setItem(this.gameObject, this.arma);
                }
            }
            else if(this.slot2.estaVacio() && this.slot.estaVacio())
            {
                this.slot.setItem(this.gameObject, this.arma);
            }
        }

        if(this.gameObject.tag == "Arma_especial")
        {
            this.slot3.setItem(this.gameObject, this.arma);
        }

    }

}