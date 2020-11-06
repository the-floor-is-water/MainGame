using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onClickStart : MonoBehaviour
{
   public void Onclickinicio()
   {
       //Debug.Log("Entro");
     
        if (Config.configuraciones.mapa==1)
        {
            Loader.loadScene("firstMap");
        }
        if (Config.configuraciones.mapa == 2)
        {
            Loader.loadScene("secondMap");
        }
   }
}
