using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Load : MonoBehaviour
{
    [SerializeField]
	private Image progressImage;

    // Start is called before the first frame update
    void Start()
    {
        string nextlevel = LoadLevel.levelName;

            StartCoroutine(this.makeLoading(nextlevel));


    }

    IEnumerator makeLoading(string nextlevel)
    {

         AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nextlevel);
        //Bloqueamos el salto automático entre escenas para asegurarnos el control durante el proceso
		asyncLoad.allowSceneActivation = false;

        while (asyncLoad.progress < 0.9f) {

			//Actualizamos la barra de carga
			progressImage.fillAmount = asyncLoad.progress;

			// de momento para que se notara la escena de carga, en producción se puede retirar sin problemas el waitForSeconds
            yield return new WaitForSeconds(1f);
		}
        progressImage.fillAmount = 1;

		//Activamos el salto de escena.
		asyncLoad.allowSceneActivation = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
