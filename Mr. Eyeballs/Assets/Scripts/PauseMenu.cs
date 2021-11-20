using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;

    public GameObject pauseMenuUI;
  

    void Update()
    {
        GameIsPaused();          
    }

    void GameIsPaused()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AudioSource audio = GetComponent<AudioSource>();
            
            if (isGamePaused)
            {
                audio.Play();                
                Resume();
            }
            else
            {
                audio.Play();              
                Pause();
            }
        }
    }
    // Deactive PauseMenu 
    void Resume()
    {        
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;        
    }
    // Activate PauseMenu
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }
}
