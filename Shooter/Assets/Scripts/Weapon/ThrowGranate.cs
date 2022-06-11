using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGranate : MonoBehaviour
{
    public float throwForce = 500;
    public GameObject granadePrefab;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            Throw();
        }
    }

    public void Throw()
    {
        GameObject newGaranade = Instantiate(granadePrefab, transform.position, transform.rotation);
        newGaranade.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce);
    }
}
