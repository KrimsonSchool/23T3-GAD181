using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gManager : MonoBehaviour
{
    public Player[] players;


    public TMPro.TextMeshProUGUI mPro;

    public int noOfPlayers;

    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < noOfPlayers; i++)
        {
            players[i].gameObject.SetActive(true);
        }

        if(noOfPlayers == 3)
        {
            cam.rect = new Rect(0.5f, 0, 0.5f, 0.5f);
        }
        else
        {
            cam.rect = new Rect(0.425f, 0, 0.15f, 0.2f);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void canMove()
    {
        foreach (Player p in players)
        {
            p.move();
        }
    }

    public void win()
    {
    }
}
