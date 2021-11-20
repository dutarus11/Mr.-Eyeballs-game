using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scenes : MonoBehaviour
{
    private string scene;
    public float timeRemaining = 2.0f;
    public float seconds = 1f;
    public bool minusTime = false;
   
    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0 && minusTime == false)
        {
            StartCoroutine(RemainingTime());
        }

        if (timeRemaining <= 0)
        {
            if (gameObject.tag == "DedicationScene")
            {
                SceneManager.LoadScene("ScreenTitle");
            }
            if (gameObject.tag == "EndingScene")
            {
                SceneManager.LoadScene("Dedication");
            }

        }
    }

    IEnumerator RemainingTime()
    {
        minusTime = true;
        yield return new WaitForSeconds(seconds);
        timeRemaining -= seconds;       
        minusTime = false;
    }
}
