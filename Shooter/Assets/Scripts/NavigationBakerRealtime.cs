using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NavigationBakerRealtime : MonoBehaviour
{
    // Start is called before the first frame update
        public NavMeshSurface[] surfaces;
       public Transform[] objectsToBake;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         for (int j = 0; j < objectsToBake.Length; j++)
        {
            //objectsToBake [j].localRotation = Quaternion.Euler (new Vector3 (0, Random.Range (0, 360), 0));
        }

        for (int i = 0; i < surfaces.Length; i++) 
        {
            surfaces [i].BuildNavMesh ();    
            Debug.Log("Rebulding NavMesh");
        }    
    }
}
