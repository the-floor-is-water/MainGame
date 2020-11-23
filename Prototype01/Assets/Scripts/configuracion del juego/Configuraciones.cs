using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class Configuraciones : MonoBehaviour
{

    public Slider volMusicaBar;

    public Slider volEfectosBar;

    public Dropdown eligeMapa;

    public Dropdown eligeNumeroJugadores;

    public Dropdown eligeGraficos;

    private AudioSource[] sources;

    public Text lbCantVolumenAudio;
    public Text lbContVolumenEfectos;

    public GameObject   primerControlInicio,
                        primerControlPrincipal,
                        primerControlAjustes,
                        primerControlIniciarPartida,
                        primerContenidoEspecial,
                        primerControlCreditos,
                        primerControlConsejos;

    public GameObject   primerControlDeGraficos, 
                        primerControlDeControles;
  

    private string[] namesOptions;

    void Start() {
        this.sources = GameObject.FindSceneObjectsOfType(typeof(AudioSource)) as AudioSource[];
        this.loadOptions();
        QualitySettings.SetQualityLevel(Config.configuraciones.calidad_de_graficos, true);
        this.eligeGraficos.value = Config.configuraciones.calidad_de_graficos;
        setValueMusic(Config.configuraciones.volumenMusica);
        setValueEfectos(Config.configuraciones.volumenefectos);
    }

    //====================================================
    //      FUNCIONES DE MANEJO DE INTERFAZ POR CONTROL
    //====================================================
    public void setEventSystemOnControls(){
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(this.primerControlDeControles);
    }
    public void setEventSystemOnGraphics(){
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(this.primerControlDeGraficos);
    }

    public void setEventSystemOnSettings()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(this.primerControlAjustes);
    }
    public void setEventSystemOnPrincipal()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(this.primerControlPrincipal);
    }
    public void setEventSystemOnStartMatch()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(this.primerControlIniciarPartida);
    }
    public void setEventSystemOnSpecialContent()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(this.primerContenidoEspecial);
    }
    public void setEventSystemOnCredits()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(this.primerControlCreditos);
    }
    public void setEventSystemOnTips()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(this.primerControlConsejos);
    }

    //====================================================
    //              FUNCIONES DE CONFIGURACION
    //====================================================
    public void loadOptions() {
       
    this.namesOptions = QualitySettings.names;
    
    List<string> optionsList = new List<string>();
    
    foreach (string item in this.namesOptions)
    {
        optionsList.Add(item);
    }

    this.eligeGraficos.AddOptions(optionsList);
       
   }

   public void selectQuality(){
       string valueSelect = this.eligeGraficos.options[this.eligeGraficos.value].text;

       for (int i = 0; i < this.namesOptions.Length; i++)
       {
           if(namesOptions[i] == valueSelect)
           {
               Config.configuraciones.calidad_de_graficos = i;
               QualitySettings.SetQualityLevel(i, true);
           }
       }

   }

   public void selectMap(){
       string valueSelect = this.eligeMapa.options[this.eligeMapa.value].text;
        Config.configuraciones.mapa = int.Parse(valueSelect);
   }

    public void selectPlayers(){
       string valueSelect = this.eligeNumeroJugadores.options[this.eligeNumeroJugadores.value].text;
       Config.configuraciones.numeroJugadores = int.Parse(valueSelect);
   }

    public void setValueMusic(){
        float vol = this.volMusicaBar.value;

        lbCantVolumenAudio.text = string.Format("{0}", (int)Math.Round((vol * 100)/1));
        Config.configuraciones.volumenMusica = vol;
            
          foreach (var audio in sources)
          {
            if(audio.tag == "Musica")
                audio.volume = vol;   
          }

    }

    public void setValueEfectos(){
        float vol = this.volEfectosBar.value; 
        lbContVolumenEfectos.text = string.Format("{0}", (int)Math.Round((vol * 100)/1));
        Config.configuraciones.volumenefectos = vol;
         foreach (var audio in sources)
          {
            if(audio.tag == "Efectos")
                audio.volume = vol;   
          }
    }

     private void setValueEfectos(float vol){
         this.volEfectosBar.value = vol;
         lbContVolumenEfectos.text = string.Format("{0}", (int)Math.Round((vol * 100)/1));
         foreach (var audio in sources)
          {
            if(audio.tag == "Efectos")
                audio.volume = vol;   
          }
    }

    private void setValueMusic(float vol){
            this.volMusicaBar.value = vol;
            lbCantVolumenAudio.text = string.Format("{0}", (int)Math.Round((vol * 100)/1));
          foreach (var audio in sources)
          {
            if(audio.tag == "Musica")
                audio.volume = vol;   
          }
    }

    public void setMapa(){
        Config.configuraciones.mapa = int.Parse(this.eligeMapa.options[eligeMapa.value].text);
        Debug.Log("El valor de mapa es: " + Config.configuraciones.mapa);
    }

    public void setNumeroJugadores(){
        Config.configuraciones.numeroJugadores = int.Parse(this.eligeNumeroJugadores.options[eligeNumeroJugadores.value].text);
        Debug.Log("El valor de numeroJugadores es: " + Config.configuraciones.numeroJugadores);
    }

}