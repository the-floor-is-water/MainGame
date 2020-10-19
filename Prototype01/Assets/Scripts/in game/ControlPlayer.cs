using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

//esta clase va en cada jugador enlazando a cada uno sus respectivos slot's

public class ControlPlayer : MonoBehaviour
{


    // el slot 1 es el que marcara el item activo si toma un nuevo item este reemplaza al que esta en la casilla de activo
    public Slot slot_1; 
    
    public Slot slot_2; 
    public Slot slot_3;

    public Controles controlManager;

    private bool  dPadLevantado = true;

    public Wepon usar;
    public bool Accionar = false;
    // Update is called once per frame
    void Update()
    {

        if(this.slot_1.estaVacio() && !this.slot_2.estaVacio())
        {
            this.slot_1.setItem(this.slot_2.getItem());
            this.slot_2.clearSlot();
        }

        //paso a detectar las teclas presionadas:

        if(this.controlManager.gameObject.tag == "Teclado")
        {
            this.mapKeyboard( ); 
        }
        else
        {
            this.mapGamepad( );
        }

    }


    private void mapKeyboard(){

        if(this.controlManager.Tab)
        {
            if(!this.slot_1.estaVacio() && !this.slot_2.estaVacio())
            {
                Wepon item = this.slot_1.getItem();
                Wepon item2 = this.slot_2.getItem();
                
                item2.isActive = true;
                item.isActive = false;

                this.slot_1.setItem(item2);
                this.slot_2.setItem(item);

            }
        }

       /* if( this.controlManager.lClick && !this.slot_1.estaVacio())
        {
            Accionar = true;
            Wepon item = this.slot_1.getItem();
            usar = item;
            Debug.Log(item.nombre);
            //this.slot_1.usar_arma_o_Item();
        }*/

        if( this.controlManager.Qkey )
        {

            /* if(this.slot_2.estaVacio() && !this.slot_1.estaVacio())
            {
                this.slot_1.clearSlot();
            }
            else if(!this.slot_2.estaVacio() && this.slot_1.estaVacio())
            {
                this.slot_1.setItem( this.slot_2.getItem()  );
                this.slot_2.clearSlot();
            } */
            this.slot_1.setItem( this.slot_2.getItem()  );
            this.slot_2.clearSlot();
        }

        if( this.controlManager.Ekey )
        {
            this.slot_3.usar_arma_o_Item();
        }

        if( this.controlManager.Fkey )
        {
            this.slot_3.clearSlot();
        }

    }

    private void mapGamepad(){
        
       

        if(this.controlManager.xButton)
        {
            if(!this.slot_1.estaVacio() && !this.slot_2.estaVacio())
            {
                Wepon item = this.slot_1.getItem();
                Wepon item2 = this.slot_2.getItem();
                
                item2.isActive = true;
                item.isActive = false;

                this.slot_1.setItem(item2);
                this.slot_2.setItem(item);

            }
        }
        
        if( this.controlManager.bButton )
        {
            this.slot_1.setItem( this.slot_2.getItem() );
            this.slot_2.clearSlot();
        }

        if( this.controlManager.yButton )
        {
            this.slot_3.clearSlot();
        }


    }

    void OnTriggerEnter3D(Collision other) {
    }

    void OnCollisionStay(Collision other) {
          
          Item master = other.gameObject.GetComponent <Item> ();
            Debug.Log(master);

            if(other.gameObject.tag == "Arma")
            {
                Debug.Log("tag del arma es: "+ other.gameObject.tag + ". Tag del Player es: "+ this.gameObject.tag );
                if(this.slot_2.estaVacio() && !this.slot_1.estaVacio())
                {
                    if(!this.slot_1.getNombre().Equals(other.gameObject.name))
                    {
                        Debug.Log("arma 1 guardada en el slot 2 y arma nueva colocada en slot 1");
                        this.slot_2.setItem(this.slot_1.getItem());
                        
                        this.slot_1.setItem( master );
                    }
                }
                else if(this.slot_2.estaVacio() && this.slot_1.estaVacio())
                {
                    Debug.Log("arma nueva colocada en el slot 1");
                    this.slot_1.setItem( master );
                }
            }

            if(other.gameObject.tag == "Arma_especial")
            {
                Debug.Log("Arma especial guardada en el slot 3");
                this.slot_3.setItem( master );
            }
        
    }
    
}
