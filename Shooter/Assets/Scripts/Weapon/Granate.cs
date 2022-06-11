using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granate : MonoBehaviour
{

    public float delay =10;
    float countdown;
    public float radius = 5;
    public float explotionForce = 70;
    bool exploded =false;
    public GameObject explotionEffect;
    public AudioSource explotionSoundFx;


    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
    }
    void Explode()
    {
        Instantiate(explotionEffect, transform.position, transform.rotation);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach(var rangeObjects in colliders)
        {
            Rigidbody rb = rangeObjects.GetComponent<Rigidbody>();
            if(rb!= null)
            {
                rb.AddExplosionForce(explotionForce * 10, transform.position, radius);
            } 
            Destroy(gameObject);  
        }   
    }

    // Update is called once per frame
    void Update()
    {
       
       countdown -= Time.deltaTime;
       
        if(countdown <= 0 && exploded == false)
        {
            
            explotionSoundFx.Play();
            Explode();
            exploded = true;
          
        }
    }
}
