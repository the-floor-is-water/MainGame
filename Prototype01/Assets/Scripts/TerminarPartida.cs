using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminarPartida : MonoBehaviour
{
    // Start is called before the first frame update
    public string Ganador;
    public List<GameObject> LJugadores = new List<GameObject>();
    public int cActivos=0;
    void Start()
    {
        cActivos = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cActivos = 0;
        foreach (var item in LJugadores)
        {
            if (item.activeSelf)
            {
                cActivos++;
            }
        }
        if (cActivos == 1)
        {
            foreach (var item in LJugadores)
            {
                if (item.activeSelf)
                {
                    Ganador = item.tag;
                    Debug.Log(Ganador);
                }
            }
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Loader.loadScene("Menu");
        }
        
    }
}
