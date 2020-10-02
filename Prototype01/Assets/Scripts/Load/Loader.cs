using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public static string levelName;

    public static void loadScene(string name)
    {
        levelName = name;
        Debug.Log("El titulo del siguiente nivel es en el loader: " + levelName);
        SceneManager.LoadScene("Loading");
    } 
}
