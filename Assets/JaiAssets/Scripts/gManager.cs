using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.GraphView.GraphView;

public class gManager : MonoBehaviour
{
    public Player[] players;


    public TMPro.TextMeshProUGUI mPro;

    public int noOfPlayers;

    public Camera cam;

    float winTimer;
    bool winner;
    // Start is called before the first frame update
    void Start()
    {
        //set the noOfPlayers to be how many players where selected at the prior menu
        noOfPlayers = PlayerPrefs.GetInt("Players");

        //for every player that were selected, 
        for (int i = 0; i < noOfPlayers; i++)
        {
            //enable that players car
            players[i].gameObject.SetActive(true);
        }
        //if only 1 player is playing then
        if(noOfPlayers == 1)
        {
            //set the minimap to be at the top
            cam.rect = new Rect(0, 0, 0.15f, 0.2f);
        }
        //if 2 players are playings then
        else if(noOfPlayers == 2)
        {
            //set the minimap to be in the center 
            cam.rect = new Rect(0.425f, 0.4f, 0.15f, 0.2f);
        }
        //if 3 players are playing then
        else if(noOfPlayers == 3)
        {
            //set the minimap to be in the bottom right
            cam.rect = new Rect(0.5f, 0, 0.5f, 0.5f);
        }
        //if 4 players are playing then
        else
        {
            //set the minimap to be in the center
            cam.rect = new Rect(0.425f, 0.4f, 0.15f, 0.2f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if the boolean winner is true then
        if (winner)
        {
            //count winTimer up by seconds
            winTimer += Time.deltaTime;

            //if winTimer is greater or equals to 3 then
            if (winTimer >= 3)
            {
                //load the GamePick menu
                SceneManager.LoadScene("GamePick");
            }
        }
    }

    public void canMove()
    {
        foreach (Player p in players)
        {
            p.move();
        }
    }

    public void noMove()
    {
        foreach (Player p in players)
        {
            p.canMove = false;
            p.rb.velocity = Vector3.zero;
        }
    }

    public void win(int winnerNo)
    {
        PlayerPrefs.SetInt("player" + winnerNo + "Score", PlayerPrefs.GetInt("player" + winnerNo + "Score") + 50);
        winner = true;
    }
}
