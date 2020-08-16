using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Avisos : MonoBehaviour
{
    public Text label;

    public string[] avisos = {
                            "La salud es un estado de completo bienestar físico, mental y social, y no solamente la ausencia de afecciones o enfermedades…",
                            "El deporte es uno de los pilares de los estilos de vida saludables. Si crees que no tienes tiempo o que tu forma física no es la adecuada, no te preocupes. El deporte está al alcance de cualquiera.",
                            "Practicar diariamente una actividad física moderada tiene numerosos beneficios para la salud como el aumento a la autoestima y mejora del estado de ánimo. ",
                            "Si permaneces muchas horas sentado, levántate cada 60 minutos y camina un poco para mantener activos tus músculos. ",
                            "Ve aumentando paulatinamente la intensidad del deporte que practiques. Aprende a escuchar tu cuerpo, y trata de no forzarlo.",
                            "Elige un equipo adecuado al deporte que practicas. Un buen calzado es fundamental, así como ropa transpirable.",
                            "Lávate las manos cuando llegues a casa, antes de comer y cuando hayas estado en contacto con animales.",
                            "Todas las funciones de nuestro organismo se ven afectadas por la falta de sueño. Recuerda dormir las horas recomendadas a tu edad. ",
                            "Practica ejercicio físico, pero intenta no hacerlo justo antes de irte a dormir. El cansancio físico es la mejor forma de vencer el insomnio, pero la adrenalina podría anular este efecto. ",
                            "Los tres aspectos más importantes para mantener una salud completa son: ejercicio, dieta y sueño. La falta de una afecta al resto, así que ten cuidado de no sacrificar alguna por otra. ",
                            "Procura acudir al médico para revisiones periódicas y cada vez que sientas que dudas o molestias sobre tu estado físico o mental. ",
                            "El agua es fundamental para la vida, y como tal debemos dotar a nuestro organismo de las cantidades que necesita. Por ello es necesario ingerir una media de dos litros de líquidos por día. "
                            };

    private int index = 0;

    void Start()
    {
       this.label.text = this.avisos[this.index];
    }

    public void anterior(){
        
        if(this.index == 0)
            this.index = this.avisos.Length - 1;
        
        this.label.text = this.avisos[this.index];
        this.index--;
    }

    public void siguiente(){

        if(this.index == (this.avisos.Length - 1))
            this.index = 0;

        this.label.text = this.avisos[this.index];
        this.index++;
    }


}
