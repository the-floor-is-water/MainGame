using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    public List<GameObject> Litems = new List<GameObject>();
    public List<GameObject> Spawns = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        spawnItem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void spawnItem()
    {
        GameObject spawnear;
        
        foreach (var items in Spawns)
        {
            var random = UnityEngine.Random.Range(0, Litems.Count);
            spawnear = Instantiate(Litems[random], items.transform.position, Quaternion.identity);
            spawnear.gameObject.SetActive(true);
        }
    }
}
