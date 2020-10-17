using UnityEngine;
using UnityEngine.UI; 
using System.Collections;


//esta clase va solo el el gameobject HUD de cada jugador
public class Slot: MonoBehaviour {    

    private Item item     = null;

    //variablesque se definen en el inspector de unity
    public Image    slotImage;
    public Slider   loadCoolDown;
    
    void Update()
    {
        if(this.item == null)
            return;

        if( this.item.isActive )
            this.item.decrementTiempoDeEspera();

        if( this.item.getTiempoDeEspera() < 0 )
            this.item.setTiempoDeEspera(0);

        if(this.item.getTag() != null) 
            if(!this.item.isArma())
                this.updateUI();
    }

    public void updateUI(){

        if(this.loadCoolDown != null)
            this.loadCoolDown.value = (this.item.getTiempoDeEspera()/this.item.cooldown);
    }


    public Item getItem(){return this.item;}

    public string getNombre(){return this.item.getNombre();}

    public bool estaVacio(){
        return this.item == null;
    }

    public void setItem(Item item)
    {
        this.clearSlot();

        this.item = item;

        this.slotImage.sprite = this.item.image;

          if( this.item.isArma() )
            this.loadCoolDown.value = (this.item.getVecesUsadas()/this.item.getmaxDamage());
    }

    public void clearSlot(){

        if( this.estaVacio() )
            return;

        this.item.setTiempoDeEspera( 0 );
        
        if(this.loadCoolDown != null)
            this.loadCoolDown.value = (this.item.getVecesUsadas() / this.item.maxDamage);
        
        this.slotImage.sprite = null;
        this.item = null;
        
    }

    public void incrementaLoUsado(){

        //  Debug.Log("Valor de las veces de " + this.getNombre() + " es: " + this.vecesUsadas);
        if (this.item.getVecesUsadas() >= this.item.maxDamage)
        {
            this.itemRoto();
            return;
        }

        this.item.incrementVecesUsadas();
        // Debug.Log("Valor de las veces de " + this.getNombre() + " incrementado es: " + this.vecesUsadas);
        this.loadCoolDown.value = (this.item.getVecesUsadas()/this.item.maxDamage);
        // Debug.Log("Valor de slider " + this.getNombre() + " es " + this.loadCoolDown.value);

    }

    private void itemRoto(){
        this.item = null;
        this.slotImage.sprite = null;

    }

    public void tirarArma(){
        this.itemRoto();
    }
    
    public void usar_arma_o_Item(){

        if( !this.estaVacio() )
        {
            if( this.item.isArma() )
            {
                //aqui puedes activar la animación, como gustes
                this.incrementaLoUsado();
            }

            if(this.item.getTag() == "Arma_especial")
            {
                this.cooldown();
            }
        }

    }


    private void cooldown()
    {
        if( this.item.getTiempoDeEspera() > 0 )
            return;
        
        this.item.isActive = false;
        
        //aqui puedes activar la animación, solo los especiales les puse espera
        // a las armas normales solo les puse gasto por uso

        this.item.resetTiempoDeEspera();
        this.item.isActive = true;

    }



}