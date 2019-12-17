using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    public GameController gameController;
    public p pc;
    // Use this for initialization
    void Start()
    {
        Debug.Log("Destroy start");
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find'GameController'Script");
        }

    }

    // Update is called once per frame

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Destroy start");
       // Debug.Log("aagaya");
        if (other.tag == "Zombi")
        {
            gameObject.SetActive(false);
            Debug.Log("killed by Zombi");
            gameController.GameOverf();
            gameController.winf();
        }
        if (other.tag == "Goblin")
        {
           
                // other.gameObject.SetActive(false);
                gameObject.SetActive(false);
                Debug.Log("killed by Goblin");
                gameController.GameOverf();
                gameController.winf();
        }
    }
}
