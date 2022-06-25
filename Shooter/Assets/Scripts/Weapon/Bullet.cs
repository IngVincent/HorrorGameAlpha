using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int life;
    public GameObject concreteBulletHole;
    public AudioSource concreteBulletHoleSound;
    public AudioSource fleshBulletHoleSound;

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.CompareTag("Enemy"))
        {
           if(life >0)
           {
               life = (life-10);
               
               Debug.Log("Enemy HP: "+ life);
               
           }
           else
           {
            Destroy(collision.gameObject);

           }
        }
        

    }
}
