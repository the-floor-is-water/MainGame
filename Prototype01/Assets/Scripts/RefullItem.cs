using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefullItem : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> Litems = new List<GameObject>();
    float tiempo = 0;
    float tiempoR = 0;
    public float tiempoRecarga = 0;
     bool Active;
    void Start()
    {
        Active = true;
    }

    // Update is called once per frame
    void Update()
    {
        tiempo = tiempo + 1 * Time.deltaTime;
        if (tiempo>tiempoR && Active)
        {
            spawnItem();
            Active = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag=="Arma" || other.tag=="Arma_especial")
        {
            tiempoR = tiempo + tiempoRecarga;
            Active = true;
        }
    }
    public void spawnItem()
    {
        GameObject spawnear;
        var random = UnityEngine.Random.Range(0, Litems.Count);
        spawnear = Instantiate(Litems[random],transform.parent.position, Quaternion.identity);
        spawnear.gameObject.SetActive(true);
      
    }
}
