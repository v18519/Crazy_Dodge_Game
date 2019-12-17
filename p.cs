using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class p : MonoBehaviour
{
    public float speed ;
  public Rigidbody rb;
    public float jump = 5.0F;
    public float gravity = 20.0f;
    public bool run;
    public bool Death;
    public Animator anim;
    private Vector3 moveValues = Vector3.zero;
   private GameObject Boy;
    public GameController gameController;
    public chase c;

    /* public Text HitCount;
     public Text CoinCount;
     public Text HealthCount;
     public Text GameOver;
     public Text NextGame;
     public Text RestartGame;
     public Text Win;
     private bool Game_Over;
     private bool Next_Game;
     private bool Restart_Game;
     private bool win;
     private int Hit;
     private int Hitw = 5;
     private int Coin;
     private int Coinw = 10;
     private int Health;*/
    //public float rots = 3.0f;   
    // Use this for initialization
    void Start()
    {
       /* Game_Over = false;
        Next_Game = false;
        Restart_Game = false;
        GameOver.text = "";
        NextGame.text = "";
        RestartGame.text = "";
        Hit = 0;
        Coin = 0;
        Health = 0;*/
       // UpdateScore();
        anim = gameObject.GetComponent<Animator>();
        Debug.Log("start");
        rb = transform.GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    void Update()
    {
        
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            if (gameController.Game_Over != true)
            {
                //Debug.Log("update");
                moveValues = new Vector3(0, 0, Input.GetAxis("Vertical"));
                // Debug.Log(moveValues);
                moveValues = transform.TransformDirection(moveValues);
                moveValues *= speed;

                if (Input.GetButton("Jump"))
                {
                    moveValues.y = jump;
                }

                if (Input.GetKey("up"))
                {
                    anim.SetBool("run", true);

                }
                else
                    anim.SetBool("run", false);
            }
            else
            {
                anim.SetBool("run", false);
                c.anim.SetBool("BT", false);
            }

        }
        moveValues.y -= gravity * Time.deltaTime;
        controller.Move(moveValues * Time.deltaTime);
        transform.Rotate(0, Input.GetAxis("Horizontal")*3.0f, 0);

       /* if (Restart_Game)
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
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }

        Debug.Log("happy");
        if (Game_Over)
        {
            Debug.Log("happy2");
            RestartGame.text = "Press 'S' for Restart";
            Restart_Game = true;
           // break;
        }
        if (win)
        {
           NextGame.text = "Press 'N' for Restart";
            Next_Game = true;
           // break;
        }*/
    }

    void OnTriggerEnter(Collider other)
    {
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
        if (other.gameObject.CompareTag("hit"))
        {
            other.gameObject.SetActive(false);
            //gameController.HitCount.text = "Chunks collected : " + gameController.HitCount.ToString();
            //gameController.winf();
            Debug.Log("killed by boy");
            gameController.Hit++;
        }
        if (other.gameObject.CompareTag("Coins"))
        {
            other.gameObject.SetActive(false);
            //CoinCount.text = "Coins : " + CoinCount.ToString();
            // winf();
           
            Debug.Log("Coin Collected");
            gameController.Coin++;
           
        }
       /* if (other.gameObject.CompareTag("power"))
        {
            other.gameObject.SetActive(false);
            //gameController.HealthCount.text = "Power : " + gameController.HealthCount.ToString();
           // gameController.winf();
            Debug.Log("power gain");
            gameController.Health++;
        }*/
        UpdateScore();
    }
    public void UpdateScore()
     {

         gameController.CoinCount.text = "Coins : " + gameController.Coin.ToString();
        // gameController.HealthCount.text = "Health: " + gameController.Health.ToString();
         gameController.HitCount.text = "Chunks: " + gameController.Hit.ToString();
         gameController.winf();

     }
    /*  public void GameOverf()
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
              Next_Game = true;
          }*/


}

