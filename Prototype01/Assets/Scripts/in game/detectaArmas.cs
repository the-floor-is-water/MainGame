using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class detectaArmas: MonoBehaviour{

// variables de los slot's de armas (los setie alv en el inspector para no hacer mucho pedo):
    public Image slot1;
    public Image slot2;
    public Image slot3;


// sprites de los objetos que van en el slot 1:
// tag: 'pricipal'
    public Sprite arma1;    //'pricipal_1'
    public Sprite arma2;    //'pricipal_2'
    public Sprite arma3;    //'pricipal_3'

// sprites de los objetos que van en el slot 2:
// tag: 'secundario'

    public Sprite subArma1; //'secundario_1'
    public Sprite subArma2; //'secundario_2'
    public Sprite subArma3; //'secundario_3'

// sprites de los objetos que van en el slot 2:
// tag: 'aditamento'

    public Sprite espArma1;  //'aditamento_1'
    public Sprite espArma2;  //'aditamento_2'
    public Sprite espArma3;  //'aditamento_3'



    private void OnCollisionEnter(Collision other) {
        this.OncollisionAction( other.gameObject.tag );
    }

    private void OnCollisionStay(Collision other) {
         this.OncollisionAction( other.gameObject.tag );
    }

    private void OnCollisionExit(Collision other) {
        
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



    }

}