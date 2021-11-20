using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour
{
    public string newScene;
    ParticleController act;
    public GameObject sparks;
   
    public void Begin()
    {           
        SceneManager.LoadScene(newScene);        
    }
   
    public void Quit()
    {               
        Application.Quit();
    }
}
