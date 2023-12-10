using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{

    public int health = 100;
    public PlayerMovement playerMovement;
    public int id;
    public AudioSource playerDeathSound;
    public AudioClip clipToPlay;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
       

    }

    // Update is called once per frame
    void Update()
    {
        if (health < 0)
        {
            playerDeathSound.Play();
            playerMovement.enabled = false;
            FindObjectOfType<CureMakerGameManager>().dead++;
            gameObject.SetActive(false);
        }
    }
       

}

