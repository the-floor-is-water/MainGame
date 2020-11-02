using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.EventSystems;

public class pause: MonoBehaviour{


    public GameObject menuDePausa;

    public GameObject slots;

    private bool enPausa = false;
    
    public Slider volMusicaBar;

    public Slider volEfectosBar;

    public CamaraControl controlDeCamara;

    private AudioSource[] sources;


    public GameObject firtsControlOnPrincipal, firstControlOnSettings, firstControlOnExit; 

    void Start(){

        this.sources = GameObject.FindSceneObjectsOfType(typeof(AudioSource)) as AudioSource[];
        this.volMusicaBar.value = Config.configuraciones.volumenMusica;
        this.volEfectosBar.value = Config.configuraciones.volumenefectos;

    }

    void Update() {
        
        if( Input.GetKeyDown( KeyCode.Escape ) )
        {
            if( !this.enPausa )
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(firtsControlOnPrincipal);
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
            }

            this.enPausa = !this.enPausa;
            menuDePausa.SetActive( this.enPausa );
            slots.SetActive( !this.enPausa );
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
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(firtsControlOnPrincipal);
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
            }

        this.enPausa = !this.enPausa;
        menuDePausa.SetActive( this.enPausa );
        slots.SetActive( !this.enPausa );
        controlDeCamara.enabled = !this.enPausa;
    }


    public void setEventSystemOnSettings(){
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(this.firstControlOnSettings);
    }

    public void setEventSystemOnExit(){
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(this.firstControlOnExit);
    }
    
    public void setEventSystemOnPrincipal(){
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(this.firtsControlOnPrincipal);
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