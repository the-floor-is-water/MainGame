using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPlayMenu : MonoBehaviour
{

    public GameObject canvasMenuPlay;

    public void openpanel()
    {
        Animator animate = canvasMenuPlay.GetComponent<Animator>();

        if(animate != null)
        {
            bool isopen = animate.GetBool("Open");

            foreach( Transform child in canvasMenuPlay.transform )
            {
                child.gameObject.SetActive( isopen );
            }

            animate.SetBool("Open", !isopen);
        }

    }
}
