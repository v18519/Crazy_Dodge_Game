using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class leveleasy : MonoBehaviour
{
    //public Sceneonehard s;
    public int scene;
    //public GameObject loadingImage;
    public void ChangeToScene(int scene)
    {
        this.scene = scene;
        StartCoroutine(ChangeLevel());
    }


    IEnumerator ChangeLevel()
    {
        
       
        fade fs = GetComponent<fade>();
        //fs.BeginFade(-1);
        //loadingImage.SetActive(true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scene);

    }
   /* public void ChangeToScene1(int sceneone)
    {
        s.Start();
        this.sceneone = sceneone;
        StartCoroutine(ChangeLevel());
        

    }*/
}
