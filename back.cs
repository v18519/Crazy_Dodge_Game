using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class back : MonoBehaviour
{
    public int scene;
    public void Back(int scene)
    {
        this.scene = scene;
        StartCoroutine(ChangeLevel());
    
       //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    IEnumerator ChangeLevel()
    {


        fade fs = GetComponent<fade>();
        //fs.BeginFade(-1);
        //loadingImage.SetActive(true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scene);

    }

}
