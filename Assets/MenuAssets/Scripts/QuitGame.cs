using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{

    
    private AudioSource effectAud;

    public AudioClip buttonOn;
    public AudioClip buttonSelect;

    private void Start()
    {
        
        effectAud = GameObject.FindGameObjectWithTag("EffectPlayer").GetComponent<AudioSource>();
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Menu");
        effectAud.clip = buttonSelect; effectAud.Play();
    }

    public void MouseOver()
    {
        effectAud.clip = buttonOn; effectAud.Play();
    }
}
