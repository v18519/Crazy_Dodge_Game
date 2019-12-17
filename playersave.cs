using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playersave : MonoBehaviour {

	public void save()
    {
        PlayerPrefs.SetFloat("Boyx", transform.position.x);
        PlayerPrefs.SetFloat("Boyy", transform.position.y);
        PlayerPrefs.SetFloat("Boyz", transform.position.z);
       
        Debug.Log("a");
    }
    public void load()
    {

        float x = PlayerPrefs.GetFloat("Boyx");
        float y = PlayerPrefs.GetFloat("Boyy");
        float z = PlayerPrefs.GetFloat("Boyz");
        Debug.Log(x);
        Debug.Log(y);
        Debug.Log(z);
        transform.position = new Vector3(x, 72f, z);
    }

}
