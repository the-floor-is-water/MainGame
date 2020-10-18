using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wepon
{
     /*
    Varible que te indica si esta activo el item
    ____________________________________________
    true = activo
    false = no activo
    */
    public bool isActive = false;
    
    /*
    numero que indica el tipo de arma que lleva, donde:
    ____________________________________________
    1: arma normal
    2: pistola
    3: especial
    */
    public int type = 0;
    
    /*
    variable que solo aplica a las armas de tipo 2, donde:
    ____________________________________________   
    1: bounce bullets
    2: balloon bullets
    3: crazy bouncy bullets
    */
    public int bulletType = 0;

    //imagen que se establece en el slot para la interfaz grafica
    public Sprite  image;

    //cooldown personalizable, por default está a 5 segundos:
    public float cooldown = 5f;

    //string para guardar el nombre del Game Object (el game object se llama como el arma)
    public string  nombre;

    // string para guardar el tag
    public string  tag;

    // conteo de las veces que fue usuado el objeto antes de ser desechado
    public float vecesUsadas = 0;

    public float tiempoDeEspera    = 0;

    public int maxDamage = 10;


    public Wepon(Item item){

        this.isActive = item.isActive;
        this.type = item.type;
        this.bulletType = item.bulletType;
        this.image = item.image;
        this.cooldown = item.cooldown;
        this.nombre = item.getNombre();
        this.tag = item.getTag();
        this.vecesUsadas = item.getVecesUsadas();
        this.tiempoDeEspera = item.getTiempoDeEspera();
        this.maxDamage = item.getmaxDamage();

    }   


    public void incrementVecesUsadas(){this.vecesUsadas += 1f;}

    public void decrementTiempoDeEspera(){this.tiempoDeEspera -=Time.deltaTime;}

    public void resetTiempoDeEspera(){this.tiempoDeEspera = this.cooldown;}

    public void setTiempoDeEspera(float value){this.tiempoDeEspera = value;}
    
    public float getTiempoDeEspera(){return this.tiempoDeEspera;}

    public bool isArma(){return this.tag == "Arma";}

    public void setmaxDamage(int value){this.maxDamage = value;}

    public int getmaxDamage(){return this.maxDamage;}

    public void  setNombre(string value){this.nombre = value;}
    
    public void  setTag(string value){this.tag = value;}
    
    public void setVecesUsadas(float value){this.vecesUsadas = value;}
    
    public string  getNombre(){return this.nombre;}
    
    public string  getTag(){return this.tag;}
    
    public float getVecesUsadas(){return this.vecesUsadas;}

    public bool getisActive(){return this.isActive;}
    
    public int getType(){return this.type;}
    
    public int getBulletType(){return this.bulletType;}



}
