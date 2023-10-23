using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapePod : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public GameObject uiWinPrompt;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider Player)
    {
        // show player 1 won the game
        Debug.Log("PlayerOneWins");
        // disable movement of all characters
        playerMovement.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
