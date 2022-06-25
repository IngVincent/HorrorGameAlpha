using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickObject : MonoBehaviour
{

    public GameObject handPoint;
    private GameObject pickedObject = null;
    public bool isPicked = false;
    // Update is called once per frame
    void Update()
    {
        if(pickedObject != null )
        {
            if(Input.GetKey("r") )
            {
                Debug.Log("Stucked here");
                
               
                pickedObject.GetComponent<Rigidbody>().isKinematic = false;
                pickedObject.GetComponent<Rigidbody>().useGravity = true;
                Debug.Log( pickedObject.GetComponent<Rigidbody>().useGravity);
                
                pickedObject.gameObject.transform.SetParent(null);
                pickedObject = null;
                isPicked = false;
                
            }
            
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Carriable"))
        {
            if(Input.GetKey("e") && pickedObject==null ) 
            {
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().isKinematic = true;
                other.transform.position = handPoint.transform.position;
                other.gameObject.transform.SetParent(handPoint.gameObject.transform);
                pickedObject = other.gameObject;
                isPicked = true;
            }
        }
    }
}
