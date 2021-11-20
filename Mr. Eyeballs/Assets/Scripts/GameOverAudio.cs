using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverAudio : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(GameOverSFX());        
    }
    
    //Game Over SFX
    IEnumerator GameOverSFX()
    {
        AudioSource audio = GetComponent<AudioSource>();
        yield return new WaitForSeconds(3);
        audio.Pause();
    }
}
