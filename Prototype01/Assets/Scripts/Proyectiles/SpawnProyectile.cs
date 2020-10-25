using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProyectile : MonoBehaviour
{
    public GameObject spawnPoint;
    public List<GameObject> efectos = new List<GameObject>();
    private GameObject efectoSpawneado;
    public CamaraControl controlCamara;
    public float refrescoDisparar;
    public conexionComponentes miCon;
    public Controles controles;
    public Material matP1;
    public Material matP2;
    public Material matP3;
    public Material matP4;
    // Start is called before the first frame update
    void Start()
    {
        efectoSpawneado = efectos[0];
    }

    // Update is called once per frame
    void Update()
    {
        if ((miCon.logicaPer.disparar) && Time.time >= refrescoDisparar && !miCon.logicaPer.tirado)
        {
            miCon.logicaPer.disparar = false;
            Wepon item = miCon.logicaPer.controlador.slot_1.getItem();
            if (item.getBulletType() == 1)
            {
                efectoSpawneado = efectos[0];
            }
            if (item.getBulletType() == 2)
            {
                efectoSpawneado = efectos[1];
            }
            if (item.getBulletType() == 3)
            {
                efectoSpawneado = efectos[2];
            }
            if (efectoSpawneado.GetComponent<movimientoProyectil>()!=null)
            {
                refrescoDisparar = Time.time + 1 / efectoSpawneado.GetComponent<movimientoProyectil>().fireRate;
                spawnEfecto();
                miCon.logicaPer.controlador.slot_1.usar_arma_o_Item();
               
            }
            if (efectoSpawneado.GetComponent<movimientoProyectil2>() != null)
            {
                refrescoDisparar = Time.time + 1 / efectoSpawneado.GetComponent<movimientoProyectil2>().fireRate;
                spawnEfecto();
                miCon.logicaPer.controlador.slot_1.usar_arma_o_Item();
            }
            if (efectoSpawneado.GetComponent<movimientoProyectil3>() != null)
            {
                refrescoDisparar = Time.time + 1 / efectoSpawneado.GetComponent<movimientoProyectil3>().fireRate;
                spawnEfecto();
                miCon.logicaPer.controlador.slot_1.usar_arma_o_Item();
            }
        }
        /*if (Input.GetKey(KeyCode.Alpha1))
        {
            efectoSpawneado = efectos[0];
            Debug.Log("num1");
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            efectoSpawneado = efectos[1];
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            efectoSpawneado = efectos[2];
        }*/

    }
    public void spawnEfecto()
    {
        GameObject efecto;
        if (spawnPoint != null)
        {
            efecto = Instantiate(efectoSpawneado, spawnPoint.transform.position, Quaternion.identity);
            var render = efecto.GetComponent<Renderer>();
            if (controles.Contenedor.tag=="Jugador1")
            {
                render.material.CopyPropertiesFromMaterial(matP1);
            }
            if (controles.Contenedor.tag == "Jugador2")
            {
                render.material.CopyPropertiesFromMaterial(matP2);
            }
            if (controles.Contenedor.tag == "Jugador3")
            {
                render.material.CopyPropertiesFromMaterial(matP3);
            }
            if (controles.Contenedor.tag == "Jugador4")
            {
                render.material.CopyPropertiesFromMaterial(matP4);
            }
            efecto.gameObject.SetActive(true);
            efecto.transform.localRotation = controlCamara.target.rotation;
        }
        else
        {
            Debug.Log("No trae Arma compa");
        }
    }

}
