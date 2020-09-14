using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class detectaArmas: MonoBehaviour{

// variables de los slot's de armas (los setie alv en el inspector para no hacer mucho pedo):
    public Image slot;
    public Image slot2;

    //este slot solo lo pueden cambiar los especiales:
    public Image slot3;
    
    public Sprite arma;    



    void OnTriggerEnter3D(Collision other) {
        
       /*  Debug.Log( other.gameObject.tag );
        Debug.Log( this.gameObject.tag );
    
        if(this.gameObject.tag == "Arma")
        {
            if(this.slot2.sprite == null || this.slot.sprite == null)
            {
                this.slot2.sprite = this.slot.sprite;
                this.slot.sprite = this.arma;
            }
        }

        if(this.gameObject.tag == "Arma_especial")
        {
            this.slot3.sprite = this.arma;
        }*/
    }

    void OnCollisionStay(Collision other) {
        Debug.Log( other.gameObject.tag );
        Debug.Log( this.gameObject.tag );
    
        if(this.gameObject.tag == "Arma")
        {
            if(this.slot2.sprite == null && this.slot.sprite != null)
            {
                if(this.slot.sprite != this.arma)
                {
                    this.slot2.sprite = this.slot.sprite;
                    this.slot.sprite = this.arma;
                }
            }
            else if(this.slot2.sprite == null && this.slot.sprite == null)
            {
                this.slot.sprite = this.arma;
            }
        }

        if(this.gameObject.tag == "Arma_especial")
        {
            this.slot3.sprite = this.arma;
        }

    }

 /*   void OnCollisionExit(Collision other) {
        
    }


    private void OncollisionAction( string name )
    {

        string[] parts = name.Split( '_' );
        string type = parts[ 0 ];
        int whichWeapon = int.Parse ( parts[ 1 ] );

        switch ( type )
        {
            case "pricipal":
            {
                switch ( whichWeapon )
                {
                    case 1:
                    {
                        this.slot1.sprite = this.arma1; 
                    }
                    break;
                    case 2:
                    {
                        this.slot1.sprite = this.arma2; 
                    }
                    break;
                    case 3:
                    {
                        this.slot1.sprite = this.arma3; 
                    }
                    break;
                }
            }
            break;
            case "secundario":
            {
                switch ( whichWeapon )
                {
                    case 1:
                    {
                        this.slot2.sprite = this.subArma1; 
                    }
                    break;
                    case 2:
                    {
                        this.slot2.sprite = this.subArma2; 
                    }
                    break;
                    case 3:
                    {
                        this.slot2.sprite = this.subArma3; 
                    }
                    break;
                }
            }
            break;
            case "aditamento":
            {
                switch ( whichWeapon )
                {
                    case 1:
                    {
                            this.slot3.sprite = this.espArma1; 
                    }
                    break;
                    case 2:
                    {
                            this.slot3.sprite = this.espArma2; 
                    }
                    break;
                    case 3:
                    {
                            this.slot3.sprite = this.espArma3;    
                    }
                    break;
                }
            }
            break;
        }



    }*/

}