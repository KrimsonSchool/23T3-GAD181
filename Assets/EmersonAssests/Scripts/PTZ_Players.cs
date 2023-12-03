using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PTZ_Players : MonoBehaviour
{
    public int pokePoints;

    public GameObject gameRun;
    public PTZ_GameRun gr;
    private PTZ_Timer tim;

    public TextMeshProUGUI playerLabel;

    public Material playerMechMaterial;
    public GameObject robot;

   // public Sprite mDefault;
   // public Sprite mHighlight;

    public TextMeshProUGUI scoreText;

    public Sprite handColour;

   // public GameObject goblin;
    //private Animator gobAnim;

    private string animationName;
    public int playerNo;

    public Texture playerScoreBox;
    public Texture inactiveBox;

    // Start is called before the first frame update
    void Start()
    {
        gr = gameRun.GetComponent<PTZ_GameRun>();
        tim = gameRun.GetComponent<PTZ_Timer>();
        //gobAnim = goblin.GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (gr._activePlayer == this.gameObject && !gr.gameEnded)
        {
            this.gameObject.GetComponent<RawImage>().texture = playerScoreBox;
            robot.GetComponent<Renderer>().material = playerMechMaterial;


        }
        else if (!gr.gameEnded || (gr._activePlayer == this.gameObject && gr.gameEnded))
        {
            this.gameObject.GetComponent<RawImage>().texture = inactiveBox;


        }

    }




    public void WinMode()
    {

        this.gameObject.GetComponent<RawImage>().texture = playerScoreBox;
        robot.GetComponent<Renderer>().material = playerMechMaterial;

        Debug.Log("The winner is " + this.playerLabel + " with " + pokePoints + " points!");

        PlayerPrefs.SetInt("player" + playerNo + "Score", PlayerPrefs.GetInt("player" + playerNo + "Score") + 50);
    }
}
