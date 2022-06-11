using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerInteractions : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public GameObject EnterToContinueCanvas;

    public AudioSource gameOverSound;
    public AudioSource hurtPlayerSound;

    public Image image;
    public float newAlpha = 0.8f;
    public float oldAlpha = 0f;
    public static bool deathPlayer; 

    IEnumerator  gotHurt()
    {
      Color newColor = image.color;
      newColor.a = newAlpha;
      image.color = newColor;
      yield return new WaitForSeconds(2);
      newColor.a = oldAlpha;
      image.color = newColor;
    }

    public void gotHurtFunction()
    {
      Color newColor = image.color;
      newColor.a = newAlpha;
      image.color = newColor;
    }
   private void OnTriggerEnter(Collider other)
   {
       if(other.gameObject.CompareTag("GunAmmo"))
       {
           GameManager.Instance.gunAmmo += other.gameObject.GetComponent<AmmoBox>().ammo;
           Destroy(other.gameObject);
          // Debug.Log("Ammo + 10");

       }
       if(other.gameObject.CompareTag("GunAmmo"))
       {
           if( GameManager.Instance.health < 100){
           GameManager.Instance.health += other.gameObject.GetComponent<AmmoBox>().ammo;
          // Debug.Log("Health + 10");

           }
       }
       if(other.gameObject.CompareTag("Enemy")&& GameManager.Instance.health > 0) 
       {
           StartCoroutine(gotHurt());
           //Debug.Log("HurtCanvas");
           GameManager.Instance.health += other.gameObject.GetComponent<EnemyHit>().dammage;  //Decrease Life
           hurtPlayerSound.Play();
           // Debug.Log("HP - 10 ");
            if(GameManager.Instance.health <= 0)
            {
                Debug.Log("Muerto");
                gameOverCanvas.SetActive(true);
                EnterToContinueCanvas.SetActive(true);
                Time.timeScale = 0; //This stops the Time in the whole world
                gameOverSound.Play();
                deathPlayer = true;
                
            }
        
       }
       
   }
}
