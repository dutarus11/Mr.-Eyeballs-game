using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro; 
public class EnemyController : MonoBehaviour
{
    [Header("Unity Setup")]
    public ParticleSystem deathParticle;
          
    public int hitPoints = 10;

    private static int scorePoints;
    public int scoreValue;
    
    public int seconds = 1;

    bool isforceFieldActive;
    bool isScoreAdding;
    
    bool ifDead;
    bool hasAbsorbed;
    
    public TextMeshProUGUI ScoreDisplay;
    public TextMeshProUGUI plusScoreDisplay;
   
    public GameObject enemyObj;
    public GameObject triLord;
    private GameObject retrieveAudioObj;
    public GameObject continueBotton2;
    private MusicController2 mus2;
    public static bool atZero = false;
    public string newScene2;
    public AudioSource SFX2;
    public GameObject audio2;
    MusicController mus;
    GameController count;
    GameController eye;
    
    public GameObject gameOverDisplay;
    public GameObject backGroundMusic;



    public bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        ifDead = false;
        scorePoints = 0;        
        plusScoreDisplay.enabled = false;               
        ScoreDisplay.text = "Score:" + scorePoints;

        mus = GameObject.FindGameObjectWithTag("Music").GetComponent<MusicController>();
       
        eye = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        
      
        if (atZero)
        {
            gameOverDisplay.SetActive(false);
        }
    }

    void Update()
    {        
        DestroyEnemy();
        if (ifDead == true)
        {
            scorePoints += scoreValue;
            ScoreDisplay.text = "Score:" + scorePoints.ToString();          
        }
        if (eye.minion == 0)
        {
            LivesFunction();
            continueBotton2.SetActive(true);                       
        }
    }
  
    //Destroy the Enemy 
    public void DestroyEnemy()
    {
        if (hitPoints <= 0)
        {
            SFX2.Play();
            eye.minion--;
            deathParticle = Instantiate(deathParticle, transform.position, Quaternion.identity) as ParticleSystem;                                   
            Destroy(deathParticle, 4.0f);                        
            Destroy(this.gameObject);
            ifDead = true;
            
        }
    }
   

        void OnTriggerEnter(Collider other)
    {        
        if (other.tag == "Player")
        {           
            Debug.Log("Damage Success!");           
            other.gameObject.GetComponent<PlayerController>().lives -= 1;                       
        }
       
    }

    public void LivesFunction()
    {
        {
            atZero = true;
            gameOverDisplay.SetActive(true);
            backGroundMusic.SetActive(false);
            StartCoroutine(GameOverUI());
            
        }
    }

    IEnumerator GameOverUI()
    {
        Time.timeScale = 0f;
        yield return new WaitForSeconds(5);
        
        SceneManager.LoadScene(newScene2);
        
    }




}