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

    public float tiempo,activar = 0;


    public GameObject firtsControlOnPrincipal, firstControlOnSettings, firstControlOnExit;

    public GameObject PanelPrincipal, PanelAjustes, PanelSalir;
    public Controles controlManager;
    public Controles controlManager2;
    public Controles controlManager3;
    public Controles controlManager4;
    void Start(){

        this.sources = GameObject.FindSceneObjectsOfType(typeof(AudioSource)) as AudioSource[];
        this.volMusicaBar.value = Config.configuraciones.volumenMusica;
        this.volEfectosBar.value = Config.configuraciones.volumenefectos;

    }

    void Update() {
        tiempo = tiempo + 1 * Time.deltaTime;
        if (activar!=0)
        {
            activarControles();
        }
        if ( Input.GetKeyDown( KeyCode.Escape ) || controlManager.startButton || controlManager2.startButton || controlManager3.startButton || controlManager4.startButton)
        {
            controlManager.startButton = false;
            controlManager.active = false;
            controlManager2.startButton = false;
            controlManager2.active = false;
            controlManager3.startButton = false;
            controlManager3.active = false;
            controlManager4.startButton = false;
            controlManager4.active = false;
            if ( !this.enPausa )
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
                activar = tiempo + .001f;
               
                
            }

            this.enPausa = !this.enPausa;
            menuDePausa.SetActive( this.enPausa );
            this.initPause(this.enPausa);
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
                activar = tiempo + .001f;
        }

        this.enPausa = !this.enPausa;
        menuDePausa.SetActive( this.enPausa );
        slots.SetActive( !this.enPausa );
        controlDeCamara.enabled = !this.enPausa;
    }

    private void initPause(bool enPausa)
    {
        if (enPausa)
        {
            this.PanelPrincipal.SetActive(enPausa);
            this.PanelAjustes.SetActive(!enPausa);
            this.PanelSalir.SetActive(!enPausa);
            setEventSystemOnPrincipal();
        }
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
    public void activarControles()
    {

        if (tiempo> activar)
        {
            controlManager.active = true;
            controlManager2.active = true;
            controlManager3.active = true;
            controlManager4.active = true;
            activar = 0;
        }
        
    }




}