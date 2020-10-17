using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controles : MonoBehaviour
{
    /*
     Consideraciones de uso de controles
    Los controles que tienen down son un click es decir hace la accion una vez
    Los controles que no tienen down, son acciones que se quedan haciendo

    Uso de Dpad-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Si el valor de dpadVertical es 1 significa que el Dpad fue presionado en la cruceta de arriba y si su valor es -1 fue presionado en la cruceta de abajo
    Para evitar problemas con el Dpad recomiendo usar:
    Una variable  auxiliar para que solo se haga una pulsacion
    bool  dPadLevantado = true;
    Condicion para resetear la variable auxiliar
    if (controles.dpadVertical == 0 && controles.dpadHorizontal == 0)
            {
                dPadLevantado = true;
            }
    Pulsacion de cruceta en vertical arriba
     if (controles.dpadVertical == 1 && dPadLevantado)
            {
                dPadLevantado = false;
            }
     Pulsacion de cruceta en vertical abajo
     if (controles.dpadVertical == -1 && dPadLevantado)
            {
                dPadLevantado = false;
            }


    Para cualquier otro boton ---------------------------------------------------------------------------------------------------------------------------------------------------------------
    if (controles.aButton || controles.spacebar)
                {
                    //metodo a ejecutar
                 
                }
     */
    // Start is called before the first frame update
    // Gatillo derecho inferior
    public float rTriggerFloat;
    // Gatillo izquierdo inferior
    public float lTriggerFloat;
    // Gatillo izquiero superior
    public bool leftBumper;
    // Gatillo derecho superior
    public bool rightBumper;
    // Boton que esta a la izquierda de pausa
    public bool backButton;
    // Boton de pausa
    public bool startButton;
    // Boton A
    public bool aButton;
    // Boton B
    public bool bButton;
    // Boton X
    public bool xButton;
    // Boton Y
    public bool yButton;
    // Dpad/Cruceta en axis horizontal
    public float dpadHorizontal;
    // Dpad/Cruceta en axis vertical
    public float dpadVertical;
    // Joystick izquierdo horizontal horizontal
    public float moveHL;
    // Joystick izquiedo axis vertical
    public float moveVL;
    // Joystick derecho axis horizontal
    public float moveHR;
    // Joystick derecho axis vertical
    public float moveVR;
    //------------------------------------------------------------Controles teclado----------------------------------------------------------------------------------------------------------------
    //Variable auxiliar para el movimiento del personaje en teclado, no le muevas a esta 
    public bool teclado = false;
    //Tecla  numerica 3
    public bool num3;
    //Barra espaciadora
    public bool spacebar;
    //Tecla control izquiedo
    public bool lControl;
    //Tecla de shift izquierdo
    public bool lShift;
    //Click izquierdo
    public bool lClick;
    //Tecla Q
    public bool Qkey;
    //Tecla E
    public bool Ekey;
    //Tecla F
    public bool Fkey;
    //Tabulador
    public bool Tab;
    //Referencia al jugador n
    public GameObject Contenedor;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Contenedor.tag == "Teclado")
        {
            moveHL = Input.GetAxis("HorizontalTeclado");
            moveVL = Input.GetAxis("VerticalTeclado");
            num3 = Input.GetKeyDown(KeyCode.Alpha3);
            spacebar = Input.GetKeyDown(KeyCode.Space);
            lControl = Input.GetKey(KeyCode.LeftControl);
            lShift = Input.GetKey(KeyCode.LeftShift);
            moveHR = Input.GetAxis("Mouse XTeclado");
            moveVR = Input.GetAxis("Mouse YTeclado");
            lClick = Input.GetMouseButton(0);
            Qkey = Input.GetKeyDown(KeyCode.Q);
            Ekey = Input.GetKeyDown(KeyCode.E);
            Fkey = Input.GetKeyDown(KeyCode.F);
            Tab = Input.GetKeyDown(KeyCode.Tab);

        }
        if (Contenedor.tag == "Jugador1")
        {
            rTriggerFloat = Input.GetAxis("Right Trigger");
            lTriggerFloat = Input.GetAxis("Left Trigger");
            leftBumper = Input.GetButton("Left Bumper");
            rightBumper = Input.GetButton("Right Bumper");
            backButton = Input.GetButton("Back");
            startButton = Input.GetButton("Start");
            aButton = Input.GetButtonDown("A Button");
            bButton = Input.GetButtonDown("B Button");
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
            bButton = Input.GetButtonDown("B Button2");
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
            bButton = Input.GetButtonDown("B Button3");
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
            bButton = Input.GetButtonDown("B Button4");
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
