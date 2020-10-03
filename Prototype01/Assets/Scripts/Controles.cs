using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controles : MonoBehaviour
{
    // Start is called before the first frame update
    public float rTriggerFloat;
    public float lTriggerFloat;
    public bool leftBumper;
    public bool rightBumper;
    public bool backButton;
    public bool startButton;
    public bool aButton;
    public bool bButton;
    public bool xButton;
    public bool yButton;
    public float dpadHorizontal;
    public float dpadVertical;
    public float moveHL;
    public float moveVL;
    public float moveHR;
    public float moveVR;
    public GameObject Contenedor;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Contenedor.tag == "Jugador1")
        {
            rTriggerFloat = Input.GetAxis("Right Trigger");
            lTriggerFloat = Input.GetAxis("Left Trigger");
            leftBumper = Input.GetButton("Left Bumper");
            rightBumper = Input.GetButton("Right Bumper");
            backButton = Input.GetButton("Back");
            startButton = Input.GetButton("Start");
            aButton = Input.GetButtonDown("A Button");
            bButton = Input.GetButton("B Button");
            xButton = Input.GetButton("X Button");
            yButton = Input.GetButton("Y Button");
            dpadHorizontal = Input.GetAxis("Dpad Horizontal");
            dpadVertical = Input.GetAxis("Dpad Vertical");
            moveHL = Input.GetAxis("Horizontal");
            moveVL = Input.GetAxis("Vertical");
            moveHR = Input.GetAxis("Mouse X");
            moveVR = Input.GetAxis("Mouse Y");
        }
        if (Contenedor.tag == "Jugador2")
        {
            rTriggerFloat = Input.GetAxis("Right Trigger2");
            lTriggerFloat = Input.GetAxis("Left Trigger2");
            leftBumper = Input.GetButton("Left Bumper2");
            rightBumper = Input.GetButton("Right Bumper2");
            backButton = Input.GetButton("Back2");
            startButton = Input.GetButton("Start2");
            aButton = Input.GetButtonDown("A Button2");
            bButton = Input.GetButton("B Button2");
            xButton = Input.GetButton("X Button2");
            yButton = Input.GetButton("Y Button2");
            dpadHorizontal = Input.GetAxis("Dpad Horizontal2");
            dpadVertical = Input.GetAxis("Dpad Vertical2");
            moveHL = Input.GetAxis("Horizontal2");
            moveVL = Input.GetAxis("Vertical2");
            moveHR = Input.GetAxis("Mouse X2");
            moveVR = Input.GetAxis("Mouse Y2");
        }
        if (Contenedor.tag == "Jugador3")
        {
            rTriggerFloat = Input.GetAxis("Right Trigger3");
            lTriggerFloat = Input.GetAxis("Left Trigger3");
            leftBumper = Input.GetButton("Left Bumper3");
            rightBumper = Input.GetButton("Right Bumper3");
            backButton = Input.GetButton("Back3");
            startButton = Input.GetButton("Start3");
            aButton = Input.GetButtonDown("A Button3");
            bButton = Input.GetButton("B Button3");
            xButton = Input.GetButton("X Button3");
            yButton = Input.GetButton("Y Button3");
            dpadHorizontal = Input.GetAxis("Dpad Horizontal3");
            dpadVertical = Input.GetAxis("Dpad Vertical3");
            moveHL = Input.GetAxis("Horizontal3");
            moveVL = Input.GetAxis("Vertical3");
            moveHR = Input.GetAxis("Mouse X3");
            moveVR = Input.GetAxis("Mouse Y3");
        }
        if (Contenedor.tag == "Jugador4")
        {
            rTriggerFloat = Input.GetAxis("Right Trigger4");
            lTriggerFloat = Input.GetAxis("Left Trigger4");
            leftBumper = Input.GetButton("Left Bumper4");
            rightBumper = Input.GetButton("Right Bumper4");
            backButton = Input.GetButton("Back4");
            startButton = Input.GetButton("Start4");
            aButton = Input.GetButtonDown("A Button4");
            bButton = Input.GetButton("B Button4");
            xButton = Input.GetButton("X Button4");
            yButton = Input.GetButton("Y Button4");
            dpadHorizontal = Input.GetAxis("Dpad Horizontal4");
            dpadVertical = Input.GetAxis("Dpad Vertical4");
            moveHL = Input.GetAxis("Horizontal4");
            moveVL = Input.GetAxis("Vertical4");
            moveHR = Input.GetAxis("Mouse X4");
            moveVR = Input.GetAxis("Mouse Y4");
        }

    }
}
