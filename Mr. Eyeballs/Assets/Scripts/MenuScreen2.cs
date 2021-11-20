using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreen2 : MonoBehaviour
{
    public string newScene2;
    ParticleController act;
    public GameObject sparks;

    public void Begin()
    {
        SceneManager.LoadScene(newScene2);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
