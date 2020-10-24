using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraControl : MonoBehaviour
{
    public bool activeTP;
    public Transform posTP;
    public Transform posPP;
    public float rotSpeed;
    public float rotSpine = 0;
    public float rootMin, rootMax;
    public float mouseX, mouseY;
    public Transform target, player;
    public Controles controles;
    public LogicaPersonaje1 personaje;
    public GameObject Head;
    public GameObject Spine;
    public bool resetRot = false;
    public bool aux = false;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = posPP.position;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Cam();

        if (activeTP == false && Input.GetKeyDown(KeyCode.Tab))
        {
            activeTP = true;
            transform.position = posPP.position;
        }
        else if (activeTP == true && Input.GetKeyDown(KeyCode.Tab))
        {
            activeTP = false;
            transform.position = posTP.position;

        }
        if (personaje.armaDisparo)
        {
            activeTP = false;
            transform.position = posTP.position;
        }
        if (!personaje.armaDisparo)
        {
            activeTP = true;
            transform.position = posPP.position;

        }
        if (personaje.tirado)
        {
            activeTP = true;
            transform.position = posPP.position;
 
        }

    }
    public void Cam()
    {
        if (personaje.tGolpe)
        {
            mouseX += rotSpeed * controles.moveHR;
            mouseY -= rotSpeed * controles.moveVR;
            mouseY = Mathf.Clamp(mouseY, rootMin, rootMax);
            target.rotation = Quaternion.Euler(mouseY, mouseX, 0f);
            player.rotation = Quaternion.Euler(0f, mouseX, 0f);
            if (!personaje.tArmaD)
            {
                Head.transform.localRotation = Quaternion.Euler(mouseY, 0, 0);
            }
            rotSpine += rotSpeed * controles.moveHR;
            if (personaje.x==0 && personaje.y==0)
            {
                resetRot = false;
                aux = true;
            }
            else
            {
                resetRot = true;
            }
            if (resetRot && aux)
            {
                rotSpine = 0;
                aux = false;
            }
            if (!personaje.tArmaD)
            {
                if (rotSpine > 30 || rotSpine < -30)
                {
                    if (rotSpine > 30)
                    {
                        rotSpine = 30;
                    }
                    if (rotSpine < -30)
                    {
                        rotSpine = -30;
                    }
                }
                if (personaje.estoyCorriendo || personaje.estoyAgachado && !personaje.cicloCotonete)
                {
                    Spine.transform.localRotation = Quaternion.Euler(35, rotSpine, 0);
                }
                else
                {
                    if (personaje.cicloCotonete)
                    {
                        Spine.transform.localRotation = Quaternion.Euler(-personaje.posBX, rotSpine, 0);
                    }
                    else
                    {
                        Spine.transform.localRotation = Quaternion.Euler(0, rotSpine, 0);
                    }
                    
                }    
            }
            





        }
        
          

    }
}
