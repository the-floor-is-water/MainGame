using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadLevel
{

    public static string levelName;

    void Start()
    {
    }


    public static void loadScene(string name)
    {
        levelName = name;

        SceneManager.LoadScene("Loading");

    } 
   


}
