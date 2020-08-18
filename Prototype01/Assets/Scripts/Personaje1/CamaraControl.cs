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
       
        if (activeTP==false && Input.GetKeyDown(KeyCode.Tab))
        {
            activeTP = true;
            transform.position = posPP.position;
        }
        else if (activeTP == true && Input.GetKeyDown(KeyCode.Tab))
        {
            activeTP = false;
            transform.position = posTP.position;
         
        }
        
    }
    public void Cam()
    {
        mouseX += rotSpeed * Input.GetAxis("Mouse X");
        mouseY -= rotSpeed * Input.GetAxis("Mouse Y");
        mouseY = Mathf.Clamp(mouseY,rootMin,rootMax);
        target.rotation = Quaternion.Euler(mouseY, mouseX, 0f);
        player.rotation = Quaternion.Euler(0f,mouseX,0f);

    }
}
