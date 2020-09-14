using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class items : MonoBehaviour
{


    // el slot 1 es el que marcara el item activo si toma un nuevo item este reemplaza al que esta en la casilla de activo
    public Image slot_1; 
    
    public Image slot_2; 
    public Image slot_3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate() {
        
    }

    // Update is called once per frame
    void Update()
    {

        //paso a detectar las teclas presionadas:

        if( Input.GetKeyDown( KeyCode.C ) ){
            Sprite arm1 = this.slot_1.sprite;
            Sprite arm2 = this.slot_2.sprite;
            
            if(arm1 != null && arm2 != null)
            {
                this.slot_1.sprite = arm2;
                this.slot_2.sprite = arm1;
            }
           
        }


        if( Input.GetKeyDown( KeyCode.Q ) )
        {
            this.slot_1.sprite = this.slot_2.sprite;
            this.slot_2.sprite = null;

        }

        if( Input.GetKeyDown( KeyCode.E ))
        {

        }


        
    }





}
