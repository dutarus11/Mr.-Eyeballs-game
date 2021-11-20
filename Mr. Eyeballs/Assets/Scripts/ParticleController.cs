using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;




public class ParticleController : MonoBehaviour
{

    [Header("Unity Setup")]
    
    public ParticleSystem particlePickUp;
    public GameObject audio2;
    public GameObject continueBotton;
    public AudioSource SFX;
    
    public float timeObjRemaining = 2.0f;
    public float seconds = 1f;
    public bool minusTime = false;
    public bool isActive = false;
   
    MusicController mus;
   
    GameController eye;
    
    public bool hasAbsorbed = false;
    public bool isShieldActive = false;
    public static bool atZero = false;

    void Start()
    {
        eye = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        mus = GameObject.FindGameObjectWithTag("Music").GetComponent<MusicController>();
        
        if (atZero)
        {
            eye.winningScreen.SetActive(false);           
        }        
       
    }
   void Update()
    {
        if (eye.gatherSpheres == 0)
        {
            atZero = true;
            eye.winningScreen.SetActive(true);
            continueBotton.SetActive(true);
            mus.audio1.Stop();
                        
            if (eye.winningScreen == true)
            {
                audio2.SetActive(true);
                Time.timeScale = 0f;
                isActive = true;                               
            }                      
        }
        
    }
    // hiting the powerups   
    public void OnCollisionEnter(Collision coll) 
    {
        Debug.Log(coll.collider.name);
        hasAbsorbed = true;

        if (coll.gameObject.name == "Mr.Eyeballs")
        {            
            AudioSource audio = GetComponent<AudioSource>();
            Debug.Log("We hit the true sphere!");
            particlePickUp = Instantiate(particlePickUp, transform.position, Quaternion.identity);
            SFX.Play();
            StartCoroutine(Autodestroy());
            Destroy(particlePickUp, 2.0f);
            eye.gatherSpheres--;
            
            isShieldActive = true;           
        }
      
        //Destroy Object Method 
        IEnumerator Autodestroy()
        {
            yield return new WaitForSeconds(particlePickUp.main.duration);                       
            Destroy(this.gameObject);           
        }
        






    }






}



