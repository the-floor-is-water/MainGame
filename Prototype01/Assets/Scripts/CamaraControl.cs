using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraControl : MonoBehaviour
{
    public bool activeTP;
    public Transform posTP;
    public Transform posPP;
    public float rotSpeed;
    public float rootMin, rootMax;
    float mouseX, mouseY;
    public Transform target, player;
    public Controles controles;
    public LogicaPersonaje1 personaje;
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

        mouseX += rotSpeed * controles.moveHR;
        mouseY -= rotSpeed * controles.moveVR;
        mouseY = Mathf.Clamp(mouseY, rootMin, rootMax);
        target.rotation = Quaternion.Euler(mouseY, mouseX, 0f);
        player.rotation = Quaternion.Euler(0f, mouseX, 0f);
          

    }
}
