using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
   public static void ResumeGame()
    {
         Time.timeScale = 1f;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
