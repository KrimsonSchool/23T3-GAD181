using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public GameObject Player;
    public PlayerMovement playerMovement;
    public bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0 || health <= 0)
        {                
            isDead = true;
            playerMovement.enabled = false;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Checkpoint")
        {
            if (other.tag == "PlayerOne")
            {
                Debug.Log("Player One Wins");
            }

            if (other.tag == "PlayerTwo")
            {
                Debug.Log("Player Two Wins");
            }
            if (other.tag == "PlayerThree")
            {
                Debug.Log("Player Three Wins");
            }
            if (other.tag == "PlayerFour")
            {
                Debug.Log("Player Four Wins");
            }
        }
    }

}
