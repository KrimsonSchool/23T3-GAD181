using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        noOfPlayers = PlayerPrefs.GetInt("Players");

        for (int i = 0; i < noOfPlayers; i++)
        {
            players[i].gameObject.SetActive(true);
        }
        if(noOfPlayers == 1)
        {
            cam.rect = new Rect(0, 0, 0.15f, 0.2f);
        }
        else if(noOfPlayers == 2)
        {
            cam.rect = new Rect(0.425f, 0.4f, 0.15f, 0.2f);
        }
        else if(noOfPlayers == 3)
        {
            cam.rect = new Rect(0.5f, 0, 0.5f, 0.5f);
        }
        else
        {
            cam.rect = new Rect(0.425f, 0.4f, 0.15f, 0.2f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (winner)
        {
            winTimer += Time.deltaTime;

            if (winTimer >= 3)
            {
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
