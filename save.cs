using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
[Serializable]
class PlayerData
{
   // public int Health;
    public int Coin;
    public int Hit;
}
public class save : MonoBehaviour {

    public static save control;
    //public int Health;
    public int Coin;
    public int Hit;
   
    void Awake()
    {
        //Awake code from singletons here
    }
    public void Save()
    {
        string filename = Application.persistentDataPath + "/playInfo.dat";
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(filename, FileMode.OpenOrCreate);
        PlayerData pd = new PlayerData();
       // pd.Health = Health;
        pd.Coin = Coin;
        pd.Hit = Hit;
        bf.Serialize(file, pd);
        file.Close();
        Debug.Log("save");
    }
    public void Load()
    {
        string filename = Application.persistentDataPath + "/playInfo.dat";
        if (File.Exists(filename))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(filename, FileMode.Open);
            PlayerData pd = (PlayerData)bf.Deserialize(file);
            file.Close();
           // Health = pd.Health;
            Coin = pd.Coin;
            Hit = pd.Hit;
            Debug.Log("load");

        }
    }
}
