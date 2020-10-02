using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class Slot: MonoBehaviour {    

    private string  tag;
    private string  nombre;
    private Sprite  image;
    private float   vecesUsadas;
    private GameObject item     = null;
    private bool  activo = false;

    private float tiempoDeEspera    = 0;
    private float espera = 5f;

    //variablesque se definen en el inspector de unity
    public Image    slotImage;
    public Slider   loadCoolDown;
    
    void Update()
    {
        if( this.activo )
            this.tiempoDeEspera -= Time.deltaTime;

        if( this.tiempoDeEspera < 0 )
            this.tiempoDeEspera = 0;

        if(this.getTag() != null) 
            if(this.getTag().Equals("Arma_especial"))
                this.updateUI();
    }

    public void updateUI(){

        if(this.loadCoolDown != null)
            this.loadCoolDown.value = (this.tiempoDeEspera/this.espera);
    }


    public string getTag(){
        return this.tag;
    }
    public string getNombre(){
        return this.nombre;
    }
    public Sprite getImage(){
        return this.image;
    }
    public GameObject getItem(){
        return this.item;
    }
    public float getTiempoDeEspera(){
        return this.tiempoDeEspera;
    }
    public float getVecesUsada(){
        return this.vecesUsadas;
    }
    public bool isActivo(){
        return this.activo;
    }

    public void setTiempoDeEspera(float tiempoDeEspera){
        this.tiempoDeEspera = tiempoDeEspera;
    }
    public void setVecesUsada(float vecesUsadas){
        this.vecesUsadas = vecesUsadas;
    }
    public void setActivo(bool activo){
        this.activo = activo;
    }
    public void setItem(GameObject item){
        this.item = item;
    }    
    public void setTag(string value){
        this.tag = value;
    }    
    public void setNombre(string value){
        this.nombre = value;
    }

    public void setImage(Sprite value){
        this.image = value;

        if( this.slotImage != null )
            this.slotImage.sprite = this.image;
    }    


    public bool estaVacio(){
        return this.item == null;
    }

    public void setItem(GameObject item, Sprite image)
    {
        this.clearSlot();
        
        this.setTag( item.tag );
        this.setNombre( item.name );
        this.setImage( image );

        this.item = item;

          if( this.getTag().Equals("Arma") )
            this.loadCoolDown.value = (this.vecesUsadas/10);
    }
    public void setItem(Slot slot)
    {
        this.clearSlot();

        this.setTag( slot.getTag() );
        this.setNombre( slot.getNombre() );
        this.setImage( slot.getImage() );

        this.setTiempoDeEspera( slot.tiempoDeEspera );
        this.setVecesUsada( slot.vecesUsadas );
        this.setItem( slot.item );

        this.setActivo( slot.activo );


        if( this.getTag() != null )
            if( this.getTag().Equals("Arma") )
                if(this.loadCoolDown != null)
                    this.loadCoolDown.value = (this.vecesUsadas/10);


    }

    public void clearSlot(){
        this.setTag( null );
        this.setNombre( null );
        this.setImage( null );
        this.item = null;

        this.setActivo( false );

        this.setTiempoDeEspera( 0 );
        this.setVecesUsada( 0 );

     
        if(this.loadCoolDown != null)
            this.loadCoolDown.value = (this.vecesUsadas/10);
    }

    public void incrementaLoUsado(){

        //  Debug.Log("Valor de las veces de " + this.getNombre() + " es: " + this.vecesUsadas);
        if (this.vecesUsadas >= 10)
        {
            this.vecesUsadas = 0;
            this.loadCoolDown.value = (this.vecesUsadas/10);
            this.itemRoto();
            return;
        }

        this.vecesUsadas += 1f;
        // Debug.Log("Valor de las veces de " + this.getNombre() + " incrementado es: " + this.vecesUsadas);
        this.loadCoolDown.value = (this.vecesUsadas/10);
        // Debug.Log("Valor de slider " + this.getNombre() + " es " + this.loadCoolDown.value);

    }

    private void itemRoto(){

        this.setTag( null );
        this.setNombre( null );
        this.setImage( null );
        this.slotImage.sprite = null;
        this.item = null;

    }

    public void tirarArma(){
        this.itemRoto();
    }
    
    public void usar_arma_o_Item(){

        if( !this.estaVacio() )
        {
            if( this.getTag() == "Arma" )
            {
                //aqui puedes activar la animación, como gustes
                this.incrementaLoUsado();
            }

            if(this.getTag() == "Arma_especial")
            {
                this.cooldown();
            }
        }

    }


    private void cooldown()
    {
        if( this.tiempoDeEspera > 0 )
            return;
        
        this.activo = false;
        
        //aqui puedes activar la animación, solo los especiales les puse espera
        // a las armas normales solo les puse gasto por uso

        this.tiempoDeEspera = this.espera;
        this.activo = true;

    }



}