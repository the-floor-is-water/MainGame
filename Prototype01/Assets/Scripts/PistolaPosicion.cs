using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolaPosicion : MonoBehaviour
{
    // Start is called before the first frame update
    public LogicaPersonaje1 Personaje;
    Vector3 posInicial;
    Vector3 posAgachado;
    public GameObject Spine;
    public GameObject mano;
    public CamaraControl camara;
    Vector3 vacio;
    void Start()
    {
        posInicial = transform.localPosition;
        posAgachado = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - .5f);
        vacio = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent.localScale != vacio )
        {
            Spine.transform.localRotation = Quaternion.Euler(camara.mouseY, 0, 0);
            transform.localRotation = Quaternion.Euler(0, transform.localRotation.y / 3, 0);
        }
        if (!Personaje.puedoMoverme)
        {
            transform.parent.localScale = vacio;
        }
       
        //transform.localPosition = mano.transform.localPosition;
        /* if (Personaje.estoyAgachado)
         {
             if (transform.localPosition != posAgachado)
             {
                 transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - .05f);

             }
         }
         else if(transform.localPosition != posInicial)
         {
             transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + .05f);
         }*/
        /*valor += camara.controles.moveVR;
        transform.localRotation = Quaternion.Euler(new Vector3(0, valor, 0));*/

    }
}
