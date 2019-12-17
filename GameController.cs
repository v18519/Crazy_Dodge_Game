using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public Text HitCount;
    public Text CoinCount;
   // public Text HealthCount;
    public Text GameOver;
    public Text NextGame;
    public Text RestartGame;
    public Text Win;
    public bool Game_Over;
    public bool Next_Game;
    public bool Restart_Game;
    public bool win;
    public int Hit;
    public int Hitw = 5;
    public int Coin;
    public int Coinw = 10;
    //public p pc;
    //public int Health;
   private float timer = 120f;
    private Text Text;
   private GameObject sf;
    public save comp;
    void Start()
    {
        Game_Over = false;
        Next_Game = false;
        Restart_Game = false;
        GameOver.text = "";
        NextGame.text = "";
        RestartGame.text = "";
        //Hit = 0;
        //Coin = 0; 
        //Health = 5;
        sf = GameObject.FindWithTag("savefunction");
        comp = sf.GetComponent<save>();
        Coin = comp.Coin;
        Hit = comp.Hit; 
        Text = GetComponent<Text>();
        // UpdateScore();
        // anim = gameObject.GetComponent<Animator>();
        // Debug.Log("start");
    }
    void Update()
    {
        int level = SceneManager.GetActiveScene().buildIndex;
        if (Restart_Game)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        if (Next_Game)
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
               
                Debug.Log("loading");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            }
        }

        //Debug.Log("happy");
        if (Game_Over)
        {
           // Debug.Log("happy2");
            RestartGame.text = "Press 'S' for Restart";
            Restart_Game = true;
            // break;
        }
        if (win)
        {
            NextGame.text = "Press 'N' for Restart";
            Next_Game = true;
            // break;
        }
       timer = timer - Time.deltaTime;
       // Text.text = timer.ToString("f0");
        if (timer <= 0)
        {
            timer = 0;
           GameOverf();

         }
      // Debug.Log(timer);
    }
    public void GameOverf()
    {
        Game_Over = true;
        // Restart_Game = true;
        GameOver.text = "GAME OVER";
       

    }
    public void winf()
    {
        if (Coin >= Coinw && Hit >= Hitw)
        {
            Win.text = "!!!Winner!!!";
            win = true;
            int level = SceneManager.GetActiveScene().buildIndex;
            if (level != 4 && level != 6)
            {
                Next_Game = true;
            }
        }
    }

}
