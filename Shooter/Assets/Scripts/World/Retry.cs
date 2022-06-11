using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
     Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ResetTheGame()
    {
        
        SceneManager.LoadScene(scene.name);
        Debug.Log("Reload Scene");
        PlayerInteractions.deathPlayer = false;
    }
}
