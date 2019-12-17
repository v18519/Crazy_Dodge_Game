 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class chase : MonoBehaviour {
    public float lookRadius = 10f;
    Transform target;
    public bool BT;
    private NavMeshAgent agent;
    public Animator anim;
    private int x = 1;
    public GameController gameController;
    // Use this for initialization
    void Start() {

        target = Playertrack.instance.Boy.transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        
        

    }
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(target.position, transform.position);
        if(distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            
                anim.SetBool("BT", true);
            
        }
        else if (distance == 0)
        {
            agent.SetDestination(transform.position);
            anim.SetBool("BT", false);


        }
        if(distance <= agent.stoppingDistance)
        {
            Face();
        }
        
	}
    void Face()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation  (new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime*5f);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "boy")
        {
           other.gameObject.SetActive(false);
            //gameObject.SetActive(false);
            anim.SetBool("BT", false);
            

            Debug.Log("killed by me");
        }
    }

}
