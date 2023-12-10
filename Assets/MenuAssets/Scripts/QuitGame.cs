using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{

    
    private AudioSource effectAud;

    public AudioClip buttonOn;
    public AudioClip buttonSelect;

    public GameObject restartCheck;

    //public Animator canvasAnimator;
   // public Animator chooseAnimator;

    private void Start()
    {
        effectAud = GameObject.FindGameObjectWithTag("EffectPlayer").GetComponent<AudioSource>();
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }

    public void PlayAgain()
    {
        effectAud.clip = buttonSelect; effectAud.Play();
       // if (PlayerPrefs.GetInt("First") == 1)
       // {
            SceneManager.LoadScene("Menu");
       // }
        //restartCheck.SetActive(false);
       // canvasAnimator.SetBool("Close", true);
        //chooseAnimator.SetBool("Close", true);
    }

    public void ReturnCheck()
    {
        
        effectAud.clip = buttonSelect; effectAud.Play();
        restartCheck.SetActive(true);
    }

    public void CancelRestart()
    {
        restartCheck.SetActive(false);
        effectAud.clip = buttonSelect; effectAud.Play();
    }


    public void MouseOver()
    {
        effectAud.clip = buttonOn; effectAud.Play();
    }

    public void MouseSelect()
    {
        effectAud.clip = buttonSelect; effectAud.Play();
    }

}
