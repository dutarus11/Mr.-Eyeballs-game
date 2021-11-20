using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float turnSpeed = 50f;
    public float speed = 10f;

    public GameObject forceShield;
    public GameObject gameOverDisplay;
    public GameObject backGroundMusic;
    public GameObject continueBotton2;
    public Text lifeDisplay;
  
    public int lives = 3;
    public bool isGrounded;
    
    private const float groundY = (float).5;
    private Vector3 velocity = Vector3.zero;
    private Vector3 gravity = new Vector3(0, -20, 0);

    private float zBoundary = 45;
    private float xBoundary = 45;
    private float yBoundary = 45;
    
   
    ParticleController shield;
    bool activated = false;

    // Start is called before the first frame update
    void Start()
    {
        
        if (activated == false)
        {            
            forceShield.SetActive(false);
        }

        lifeDisplay.GetComponent<Text>().text = "Lives:" + lives;
        gameObject.GetComponent<BoxCollider>().enabled = true;
        gameOverDisplay.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Boundary();
        liveUITrack();
        if (lives == 0)
        {
            LivesFunction();
            continueBotton2.SetActive(true);
        }
        
    }

    // Movement Method 
    void Movement()
    {
        // Basic Player Movement 
        if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);

        velocity.x = Input.GetAxis("Horizontal");
        velocity.z = Input.GetAxis("Vertical");

        if (velocity.sqrMagnitude > 1)
        {
            velocity.Normalize();
            transform.position += velocity * speed * Time.deltaTime;
        }
        else
        {
            velocity += gravity * Time.deltaTime;
            Vector3 pos = transform.position + velocity * Time.deltaTime;

            if (pos.y < groundY)
            {
                pos.y = groundY;
                isGrounded = true;
                velocity.y = 0;
            }
            transform.position = pos;
        }
    }

    //Border Parameters Method
    void Boundary()
    {
        if (transform.position.z > zBoundary)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBoundary);
        }
        if (transform.position.z < -zBoundary)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBoundary);
        }
        if (transform.position.x > xBoundary)
        {
            transform.position = new Vector3(xBoundary, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -xBoundary)
        {
            transform.position = new Vector3(-xBoundary, transform.position.y, transform.position.z);
        }
        if (transform.position.y > yBoundary)
        {
            transform.position = new Vector3(transform.position.x, yBoundary, transform.position.z);
        }
    }
    
    //shield is activated 
    public void OnCollisionEnter(Collision coll)
    {
        Debug.Log("Successful Collide");
        if (coll.gameObject.tag == "Powerup")
        {
            activated = true;

            if (activated == true)
            {
                forceShield.SetActive(true);
                gameObject.GetComponent<BoxCollider>().enabled = false;
                StartCoroutine(Deactivate());
                
            }
        }       
     
    }   

    // Deactivate the shield 
    IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(20);
        activated = false;        
        forceShield.SetActive(false);
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }

    public void liveUITrack()
    {
        if (lives == lives)
        {                       
            lifeDisplay.GetComponent<Text>().text = "Lives:" + lives + "x";
        }
      
    }
    public void LivesFunction()
    {
        {            
            gameOverDisplay.SetActive(true);
            backGroundMusic.SetActive(false);
            StartCoroutine(GameOverUI());
        }
    }

    IEnumerator GameOverUI()
    {
        yield return new WaitForSeconds(1);        
        Time.timeScale = 0f;
    }


}

