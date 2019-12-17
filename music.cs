﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour {

	public void Awake()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("music");
        if (obj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
