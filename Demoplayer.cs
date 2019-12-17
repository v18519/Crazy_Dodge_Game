using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Demoplayer : MonoBehaviour
{
    public float speed=5;
    //public Transform[] moveSpots;
    //private int randomSpot;
    public Rigidbody rb;
    public float jump = 5.0F;
    public float gravity = 20.0f;
    public bool start;
    public bool Death;
    public Animator anim;
    private Vector3 moveValues = Vector3.zero;
    private GameObject Boy;
    public GameController gameController;
    public chase c;
    private bool lookAt = true;

    void Start()
    {
        anim.SetBool("start", true);
        // randomSpot = Random.Range(0, moveSpots.Length);
    }

    // Update is called once per frame
    void Update()
    {

         CharacterController controller = GetComponent<CharacterController>();
          if (controller.isGrounded)
          {
            /* //Debug.Log("update");
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
                 anim.SetBool("run", false);*/
           anim.SetBool("start", true);
        }
        /*  moveValues.y -= gravity * Time.deltaTime;
          controller.Move(moveValues * Time.deltaTime);
          //transform.Rotate(0, Input.GetAxis("Horizontal") * 3.0f, 0);*/
      /*  transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        randomSpot = Random.Range(0, moveSpots.Length);
        anim.SetBool("run", true);
        if(lookAt)
        {
            transform.LookAt(transform.position);
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

          
            gameObject.SetActive(false);
            Debug.Log("killed by Goblin");
            gameController.GameOverf();
            gameController.winf();
        }
        if (other.gameObject.CompareTag("hit"))
        {
            other.gameObject.SetActive(false);
           Debug.Log("killed by boy");
            gameController.Hit++;
        }
        if (other.gameObject.CompareTag("Coins"))
        {
            other.gameObject.SetActive(false);
            Debug.Log("Coin Collected");
            gameController.Coin++;

        }
       /* if (other.gameObject.CompareTag("power"))
        {
            other.gameObject.SetActive(false);
            
            Debug.Log("power gain");
            gameController.Health++;
        }*/
        UpdateScore();
    }
    public void UpdateScore()
    {

        gameController.CoinCount.text = "Coins : " + gameController.Coin.ToString();
        //gameController.HealthCount.text = "Power: " + gameController.Health.ToString();
        gameController.HitCount.text = "Chunks: " + gameController.Hit.ToString();
        gameController.winf();

    }
    

}

