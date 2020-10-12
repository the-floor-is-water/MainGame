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
    // Start is called before the first frame update
    void Start()
    {
        efectoSpawneado = efectos[0];
    }

    // Update is called once per frame
    void Update()
    {
        if ((controles.rTriggerFloat == 1 || controles.lClick) && Time.time >= refrescoDisparar && !miCon.logicaPer.tirado && miCon.logicaPer.armaDisparo)
        {
            if (efectoSpawneado.GetComponent<movimientoProyectil>()!=null)
            {
                refrescoDisparar = Time.time + 1 / efectoSpawneado.GetComponent<movimientoProyectil>().fireRate;
                spawnEfecto();
            }
            if (efectoSpawneado.GetComponent<movimientoProyectil2>() != null)
            {
                refrescoDisparar = Time.time + 1 / efectoSpawneado.GetComponent<movimientoProyectil2>().fireRate;
                spawnEfecto();
            }
            if (efectoSpawneado.GetComponent<movimientoProyectil3>() != null)
            {
                refrescoDisparar = Time.time + 1 / efectoSpawneado.GetComponent<movimientoProyectil3>().fireRate;
                spawnEfecto();
            }
        }
        if (Input.GetKey(KeyCode.Alpha1))
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
        }
    }
    public void spawnEfecto()
    {
        GameObject efecto;
        if (spawnPoint != null)
        {
            efecto = Instantiate(efectoSpawneado, spawnPoint.transform.position, Quaternion.identity);
            efecto.gameObject.SetActive(true);
            efecto.transform.localRotation = controlCamara.target.rotation;
        }
        else
        {
            Debug.Log("No trae Arma compa");
        }
    }

}
