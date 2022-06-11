using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;

    public float speed = 12f;


    public float gravity = -9.81f;

    public Transform groundCheck;
    public float sphereRadius = 0.3f;
    public LayerMask groundMask;
    public static bool gameIsPaused;
    public GameObject PauseButton;
    public static bool playerIsDead; 

    bool isGrounded;

    Vector3 velocity;

    public float jumpHeight =3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

        void PauseGame()
        {
            if(gameIsPaused)
            {
              Time.timeScale = 0f;
              PauseButton.SetActive(true);
            }
            else
            {
              Time.timeScale = 1f;
              PauseButton.SetActive(false); 
            }
            
                    
                
        }
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, groundMask);
        playerIsDead =PlayerInteractions.deathPlayer;
        //Debug.Log("Jugador muerto" + playerIsDead);

        if(isGrounded && velocity.y <0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        if(Input.GetKeyDown("space")&& isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            }
        characterController.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            
            Debug.Log("Running");
        }
       
        

        if(Input.GetKeyDown(KeyCode.Escape) & playerIsDead == false)
        {   
            
            gameIsPaused = !gameIsPaused;
            PauseGame();
            
        }
        else if(Input.GetKey(KeyCode.Return) & playerIsDead == true)
        {
                     Scene scene;
                     scene = SceneManager.GetActiveScene();
                     SceneManager.LoadScene(scene.name);
                     Time.timeScale = 1f;
                     PlayerInteractions.deathPlayer = false; //this line reset the live boolean used for the menu
        }
        
        }
}
