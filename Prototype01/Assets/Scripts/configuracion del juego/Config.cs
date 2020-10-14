using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Config : MonoBehaviour
{
    // conficuracion del juego, paramettros que aunque se cierre el juego no pueden cambiarse:
    public  float volumenMusica = 0;
    public  float volumenefectos = 0;

    //variables de partida, estas pueden cambiar durante el juego:
    public  int numeroJugadores = 2;
    public  int mapa = 1;

    //index de la calidad de grafico, esta en 2 por defult:
    public int calidad_de_graficos = 2;

    //variable que permite la inmunidad al gameObject que porte este script:
    public static Config configuraciones;

    private string rutaConfJuegoAplicacion;

    private AudioSource[] sources;


    void Awake ()
    {
        if(configuraciones == null) {
            //Debug.Log("no existo así que me creare a mi mismo");
            this.rutaConfJuegoAplicacion = Application.persistentDataPath + "/Conf.TFW";
            cargar();
            configuraciones = this;
             
            DontDestroyOnLoad(configuraciones);
        }
        else if(configuraciones != this)
        {
            //Debug.Log("ya existo!");
             this.ajustarConfiguraciones();
            Destroy(gameObject);
        }

       
    }

    void Start(){
        
    }

    public void ajustarConfiguraciones(){

        //Debug.Log( "Se mando a llamar el metodo ajustarConfiguraciones" );
        this.sources = GameObject.FindSceneObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (var audio in sources)
          {
            if(audio.tag == "Musica")
                audio.volume = this.volumenMusica; 

            if(audio.tag == "Efectos")
                audio.volume = this.volumenefectos;   
          }

          QualitySettings.SetQualityLevel(this.calidad_de_graficos, true);

        //Debug.Log( "se ajusto los graficos en nivel: "+ this.calidad_de_graficos); 
        //Debug.Log("se ajusto el volumen de la musica en: "+ this.volumenMusica); 
        //Debug.Log("por ultimo el volumen de los efectos fue ajustado a: " + this.volumenefectos);

        this.sources = null; 

    }

    public void guardarConfiguraciones(){
        guardar();
    }

    public void cargar(){
        if (File.Exists(this.rutaConfJuegoAplicacion))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = File.Open(this.rutaConfJuegoAplicacion, FileMode.Open);

            DatosDeConfiguracion data = (DatosDeConfiguracion) bf.Deserialize(stream);

            this.volumenMusica  = data.volumenMusica;
            this.volumenefectos = data.volumenefectos;

            this.numeroJugadores = 2;
            this.mapa = 1;       

            this.calidad_de_graficos = data.calidad_de_graficos;


            stream.Close();
        }

    }

    public void guardar(){
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = File.Create(this.rutaConfJuegoAplicacion);

        DatosDeConfiguracion data = new DatosDeConfiguracion();

        data.volumenMusica  = this.volumenMusica;
        data.volumenefectos = this.volumenefectos;

        data.calidad_de_graficos = this.calidad_de_graficos;

        bf.Serialize(stream, data);

        stream.Close();
    }


}

[Serializable]
public class DatosDeConfiguracion
{
    // conficuracion del juego, paramettros que aunque se cierre el juego no pueden cambiarse:
    public  float volumenMusica = 0;
    public  float volumenefectos = 0;

    //index de la calidad de grafico, esta en 2 por defult:
    public int calidad_de_graficos = 2;

}
