using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public GameObject timerDisplay;
   
    public float timeRemaining = 10.0f;
    public float seconds = 1f;
    public bool minusTime = false;
    
    // Start is called before the first frame update
    void Start()
    {
        timerDisplay.GetComponent<Text>().text = "Timer:" + timeRemaining;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0 && minusTime == false)
        {
            StartCoroutine(RemainingTime());
        }

        if (timeRemaining <= 0)
        {
            
            SceneManager.LoadScene("Level 1");
        }

    }

    IEnumerator RemainingTime()
    {
        minusTime = true;
        yield return new WaitForSeconds(seconds);
        timeRemaining -= seconds;
        timerDisplay.GetComponent<Text>().text = "Timer:" + timeRemaining;
        minusTime = false;      
    }

    
}
