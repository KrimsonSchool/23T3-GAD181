using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using UnityEngine.UI;

public class PTZ_PlayerAmount : MonoBehaviour
{
    public int playerAmount;

    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;
    public GameObject nothing;

    public GameObject panel;

    private PTZ_GameRun gr;

    private void Awake()
    {
        playerAmount = PlayerPrefs.GetInt("Players");

        gr = this.GetComponent<PTZ_GameRun>();

        if (playerAmount == 0 || playerAmount == 1)
        {
            playerAmount = 2;
        }
        if (playerAmount == 2)
        {
            TwoPlayers();
        }
        if (playerAmount == 3)
        {
            ThreePlayers();
        }
        if (playerAmount == 4)
        {
            FourPlayers();
        }
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TwoPlayers()
    {
        gr.playerList.Add(p1);
        gr.playerList.Add(p2);
        gr.playerList.Add(nothing);
        Destroy(p3);
        Destroy(p4);
      
        panel.GetComponent<RectTransform>().sizeDelta = new Vector2(430f, 90f);

        panel.GetComponent<HorizontalLayoutGroup>().spacing = 40f;

    }

    public void ThreePlayers()
    {
        gr.playerList.Add(p1);
        gr.playerList.Add(p2);
        gr.playerList.Add(p3);
        gr.playerList.Add(nothing);
        Destroy(p4);

        panel.GetComponent<RectTransform>().sizeDelta = new Vector2(530f, 90f);
    }

    public void FourPlayers()
    {
        gr.playerList.Add(p1);
        gr.playerList.Add(p2);
        gr.playerList.Add(p3);
        gr.playerList.Add(p4);
        gr.playerList.Add(nothing);

       
    }
}
