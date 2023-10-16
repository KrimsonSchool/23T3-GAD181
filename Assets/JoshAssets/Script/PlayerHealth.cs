using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public GameObject Player;
    public PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;

    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0 || health <= 0)
        {                
            playerMovement.enabled = false;
        }
    }
   
    

    
}
