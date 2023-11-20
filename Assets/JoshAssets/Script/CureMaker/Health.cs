using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public int health = 100;
    public PlayerMovement playerMovement;
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
            playerMovement.enabled = false;
            gameObject.SetActive(false);
        }
    }
}
