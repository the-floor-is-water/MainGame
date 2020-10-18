using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

//esta clase va en el item
public class Item : MonoBehaviour
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

    public int maxDamage = 10;

    //string para guardar el nombre del Game Object (el game object se llama como el arma)
    private string  nombre;

    // string para guardar el tag
    private string  tag;

    // conteo de las veces que fue usuado el objeto antes de ser desechado
    private float vecesUsadas = 0;

    private float tiempoDeEspera    = 0;


    
    void Start()
    {
        this.setTag( this.gameObject.tag );
        this.setNombre( this.gameObject.name );   
    }

    public Item(){

    }

    public Item (string tag, string name)
    {
        this.setTag( tag );
        this.setNombre( name );   
    }

    public Item(Item item)
    {
        this.setTiempoDeEspera( item.getTiempoDeEspera() );
        this.setmaxDamage( item.getmaxDamage() );
        this.setVecesUsadas( item.getVecesUsadas() );

        this.isActive = item.isActive;
        this.type = item.type;
        this.bulletType = item.bulletType;
        this.image = Sprite.Instantiate<Sprite>(item.image);
        this.cooldown = item.cooldown;

    }

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

