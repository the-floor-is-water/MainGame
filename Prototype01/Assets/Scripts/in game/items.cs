using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class items : MonoBehaviour
{


    // el slot 1 es el que marcara el item activo si toma un nuevo item este reemplaza al que esta en la casilla de activo
    public Slot slot_1; 
    
    public Slot slot_2; 
    public Slot slot_3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate() {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(this.slot_1.estaVacio() && !this.slot_2.estaVacio())
        {
            this.slot_1.setItem(this.slot_2);
            this.slot_2.clearSlot();
        }

        //paso a detectar las teclas presionadas:
        if( Input.GetKeyDown( KeyCode.C ) ){
            
            if(!this.slot_1.estaVacio() && !this.slot_2.estaVacio())
            {
                Slot aux_2 = new Slot();
                
                aux_2.setItem(this.slot_1);

                this.slot_1.setItem(this.slot_2);
                this.slot_2.setItem(aux_2);

            }
           
        }

        if( Input.GetKeyDown( KeyCode.L ) ){
            this.slot_1.usar_arma_o_Item();
        }

        if( Input.GetKeyDown( KeyCode.Q ) )
        {
            this.slot_1.setItem( this.slot_2 );
            this.slot_2.clearSlot();
            // this.slot_1.sprite = this.slot_2.sprite;
            // this.slot_2.sprite = null;
        }

        if( Input.GetKeyDown( KeyCode.E ))
        {
            this.slot_3.usar_arma_o_Item();
        }

        if( Input.GetKeyDown( KeyCode.F ))
        {
            this.slot_3.clearSlot();
        }

        


        
    }





}
