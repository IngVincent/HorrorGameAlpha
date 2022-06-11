using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //IA library

public class AI : MonoBehaviour
{

    public NavMeshAgent navMeshAgent;

    public Transform[] destinations;

    private int i = 0;
    [Header("-----FollowPlayer?-----")]
    public bool followPlayer;
    private GameObject player;
    public float distanceToFollowPath =2;
    public bool Hitted;

    private float distanceToPlayer;
    public float distanceToFollowPlayer = 25;

    public AudioSource screamPain; 
    void Start()
    {
        navMeshAgent.destination = destinations[0].transform.position;  
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }
    public void EnemiPath()
    {
        navMeshAgent.destination = destinations[i].position;
        if(Vector3.Distance(transform.position, destinations[i].position)<=distanceToFollowPath )
        {
            if(destinations[i] != destinations[destinations.Length -1])
            {
                i++;
            }
            else
            {
                i =0;
            }
        }
    }
    

    public void FollowPlayer()
    {
        //navMeshAgent.destination = player.transform.position;
        
            if(Hitted == true)
            {

                Debug.Log("Waiting time ...");
                //falta bloque que aleje enemigo por X segundos
                EnemiPath(); 
                StartCoroutine(EnemyHurt());

IEnumerator EnemyHurt()  //  <-  its a standalone method
{
	Debug.Log("Enemy running Away");
    yield return new WaitForSeconds(3);
    Hitted = false;
    navMeshAgent.destination = player.transform.position;
    Debug.Log("Enemy coming back");
}
                

                 
            }
            else
            {
                navMeshAgent.destination = player.transform.position;
            }
           
    }
    void OnCollisionEnter(Collision other)
 {

     if(other.gameObject.CompareTag("Bullet"))
     {
         Debug.Log("Me dieron");
         Hitted = true;
         screamPain.Play();

         
     }
 }
    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if(distanceToPlayer <= distanceToFollowPlayer & followPlayer)
        {
            FollowPlayer();
        }
        else
        {
            EnemiPath();
        }

    }
}
