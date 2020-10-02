using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickedAnimation : MonoBehaviour
{
    public GameObject Object1;
    public GameObject theFloor;
    public GameObject isWater;
    public GameObject canvas;
    public GameObject NewCanvas;

    public void execute()
    {
        openpanel(this.Object1);
        openpanel(this.theFloor);
        openpanel(this.isWater);
        openpanel(this.canvas);
        this.NewCanvas.SetActive(true);
    }

    private void openpanel(GameObject obj)
    {
        Animator animate = obj.GetComponent<Animator>();

        if(animate != null)
        {
            bool isclicked = animate.GetBool("isclicked");
            
            animate.SetBool("isclicked", !isclicked);

            foreach( Transform child in obj.transform )
            {
                child.gameObject.SetActive( isclicked );
            }

        }

       //StartCoroutine(this.waitToDisabled(obj));

    }

    IEnumerator waitToDisabled(GameObject obj){
        yield return new WaitForSeconds(5f);
        obj.SetActive(false);
    }
}
