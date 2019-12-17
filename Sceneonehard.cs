using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sceneonehard : MonoBehaviour {

    public GameObject ZOMBI2;
	// Use this for initialization
	public void Start () {
        Instantiate(ZOMBI2, transform.position, transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
