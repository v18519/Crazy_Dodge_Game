using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playertrack : MonoBehaviour
{
   #region Sinleton
    public static Playertrack instance;
    void Awake()
    {
        instance = this;
    }
    #endregion
    public GameObject Boy;
}