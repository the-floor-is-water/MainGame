using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPersonaje1 : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f;
    public float velocidadInicial;
    public float velocidadRotacion = 200f;
    public float velocidadCorriendo;
   public float velocidadAgachado;
    private Animator anim;
    public float x, y;
    public Rigidbody rb;
    public float fuerzaDeSalto = 14f;
    public bool puedoSaltar;
    public float fuerzaExtra = 0;
    public CapsuleCollider colParado;
    public CapsuleCollider colAgachado;
    public GameObject cabeza;
    public LogicaCabeza logicaCabeza;
    public bool estoyAgachado;
    public bool estoyCorriendo;
    public float refrescoCorrer = 0f;
    public float tiempo = 0f;
    public GameObject referencia;
    
    Vector3 rotationInput = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        Config.configuraciones.ajustarConfiguraciones();
        anim = GetComponent<Animator>();
        puedoSaltar=false;
        velocidadInicial = velocidadMovimiento;
        velocidadAgachado = velocidadMovimiento * .5f;
        velocidadCorriendo = velocidadMovimiento + 2f;
       
    }
    
    // Update is called once per frame
    void Update()
    {
        tiempo = tiempo + 1 * Time.deltaTime;
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        

        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);

        /*if (Input.GetMouseButton(1))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * velocidadRotacion, Space.Self);
        }
        if (Input.GetMouseButton(0))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * velocidadRotacion, Space.Self);
        }*/
        //Look();
        if (puedoSaltar)
        {
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("salte",true);
                rb.AddForce(new Vector3(0,fuerzaDeSalto, 0),ForceMode.Impulse);
                
            }
            anim.SetBool("tocarSuelo",true);
        }else
        {
            estoyCallendo();
        }
        if(Input.GetKey(KeyCode.LeftControl)){
            anim.SetBool("agachado",true);
            velocidadMovimiento = velocidadAgachado;
            
            colAgachado.enabled = true;
            colParado.enabled = false;
            cabeza.SetActive(true);
             estoyAgachado = true;
        }else{
            if(logicaCabeza.contadorDeColision<=0){
                anim.SetBool("agachado",false);
            velocidadMovimiento = velocidadInicial;

            cabeza.SetActive(false);
            colAgachado.enabled = false;
            colParado.enabled = true;
            estoyAgachado = false;
            }
        }
        if (Input.GetKey(KeyCode.LeftShift) && (y==1 || y==-1 || x==1 || x==-1) && (refrescoCorrer<=tiempo))
        {   
            
            anim.SetBool("correr", true);
            velocidadMovimiento = velocidadCorriendo;
            estoyCorriendo = true;
            if (estoyAgachado)
            {
                velocidadMovimiento *=.5f;
            }
            
        }
        else if(estoyCorriendo)
        {
            refrescoCorrer = tiempo + .5f;
            anim.SetBool("correr", false);
            estoyCorriendo = false;
            if (!estoyAgachado)
            {
               velocidadMovimiento = velocidadInicial;
            }
               
        }
        
    }
    void FixedUpdate() {
        //transform.Rotate(0, x * Time.deltaTime * velocidadRotacion,0);
        transform.Translate(x * Time.deltaTime * velocidadMovimiento, 0, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);
        
       
    }
    public void estoyCallendo(){
         anim.SetBool("tocarSuelo",false);
         anim.SetBool("salte",false);
         rb.AddForce(fuerzaExtra* Physics.gravity);
         
    }
    public void Look()
    {
        rotationInput.x = Input.GetAxis("Mouse X") * velocidadRotacion * Time.deltaTime;
        rotationInput.y = Input.GetAxis("Mouse Y") * velocidadRotacion * Time.deltaTime;
        transform.Rotate(Vector3.up * rotationInput.x);
    }
}
