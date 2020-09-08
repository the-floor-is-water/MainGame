using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class pause: MonoBehaviour{


/*

Controles de xbox 360 ( https://ritchielozada.com/2016/01/16/part-11-using-an-xbox-one-controller-with-unity-on-windows-10/ ):


A                               joystick button 0

B                               joystick button 1

X                               joystick button 2

Y                               joystick button 3

Left Bumper                     joystick button 4

Right Bumper                    joystick button 5

View (Back)                     joystick button 6

Menu (Start)                    joystick button 7

Left Stick Button               joystick button 8

Right Stick Button              joystick button 9

Left Stick “Horizontal”         X Axis                                      -1 to 1

Left Stick “Vertical”           Y Axis                                      1 to -1

Right Stick “HorizontalTurn”    4th Axis                                    -1 to 1

Right Stick “VerticalTurn”      5th Axis                                    1 to -1

DPAD – Horizontal               6th Axis                                    -1 (.64) 1

DPAD – Vertical                 7th Axis                                    -1 (.64) 1

Left Trigger                    9th Axis                                    0 to 1

Right Trigger                   10th Axis                                   0 to 1

Left Trigger Shared Axis        3rd Axis                                    0 to 1

Right Trigger Shared Axis       3rd Axis                                    0 to -1

*/
    public GameObject menuDePausa;

    public GameObject slots;

    private bool enPausa = false;
    
    public Slider volMusicaBar;

    public Slider volEfectosBar;

    public CamaraControl controlDeCamara;

    private AudioSource[] sources;

    void Start(){

        this.sources = GameObject.FindSceneObjectsOfType(typeof(AudioSource)) as AudioSource[];

    }

    void Update() {
        
        if( Input.GetKeyDown( KeyCode.Escape ) )
        {
            if( !this.enPausa )
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
            }

            this.enPausa = !this.enPausa;
            menuDePausa.SetActive( this.enPausa );
            slots.SetActive( this.enPausa );
            controlDeCamara.enabled = !this.enPausa;
        }

    }

    public void saveConfiguration(){
        Config.configuraciones.guardar();
    }

    public void closePause(){

        if( !this.enPausa )
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
            }

        this.enPausa = !this.enPausa;
        menuDePausa.SetActive( this.enPausa );
        slots.SetActive( this.enPausa );
        controlDeCamara.enabled = !this.enPausa;
    }



    public void setValueMusic(){
        float vol = this.volMusicaBar.value;
        Config.configuraciones.volumenMusica = vol;
            
          foreach (var audio in sources)
          {
            if(audio.tag == "Musica")
                audio.volume = vol;   
          }

    }

    public void setValueEfectos(){
        float vol = this.volEfectosBar.value; 
        Config.configuraciones.volumenefectos = vol;
         foreach (var audio in sources)
          {
            if(audio.tag == "Efectos")
                audio.volume = vol;   
          }
    }


    public void abandonarPartida(){
        Time.timeScale = 1;
        Loader.loadScene("Menu");
    }




}