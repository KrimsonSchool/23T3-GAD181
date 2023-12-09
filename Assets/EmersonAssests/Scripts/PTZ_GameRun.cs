using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PTZ_GameRun : MonoBehaviour
{
    public List<GameObject> playerList;

    public GameObject _activePlayer;
    public PTZ_Players activePlayer;

    private PTZ_Zombie zombie;
    private PTZ_Timer timer;

    public int x;

    public bool gameBegun;
    public bool gameEnded;

   
    public GameObject musicPlayer;

    public AudioClip[] pokeSound;
    public AudioSource effectAud;

    public GameObject mechArm;
    public Animator mechAnim;
   private AudioSource mechAud;

   public AudioClip mechIn;
   public AudioClip mechOut;

    public string winnerText;

    public GameObject explanation;
    

    // Start is called before the first frame update
    void Start()
    {
        zombie = this.gameObject.GetComponent<PTZ_Zombie>();
        timer = this.gameObject.GetComponent<PTZ_Timer>();

        x = Random.Range(0, playerList.Count - 1); // randomises which player is the first active player

        _activePlayer = playerList[x]; // sets first active player

        Debug.Log(playerList[x] + " goes first");

        gameBegun = false;
        gameEnded = false;

        

        mechAnim = mechArm.GetComponent<Animator>();    
        mechAud = mechArm.GetComponent<AudioSource>();


    }


    // Update is called once per frame
    void Update()
    {
        _activePlayer = playerList[x]; // constantly checks who the active player is
        activePlayer = _activePlayer.GetComponent<PTZ_Players>(); // makes a player the active player

             if (Input.GetKeyDown(KeyCode.Space) && !gameBegun && !gameEnded) // starts game and timer
             {
                 gameBegun = true;
                 timer.timerText.GetComponent<AudioSource>().Play();
                 explanation.SetActive(false);

             }

            if (Input.GetKeyDown(KeyCode.Space) && !gameEnded)
            {

                if (timer.targetTime >= 0.5f)
                {
                    mechAnim.SetTrigger("pokein");

                   mechAud.clip = mechIn;
                   mechAud.Play();
                }
            }
        


            if (Input.GetKeyUp(KeyCode.Space) && gameBegun && timer.targetTime >= 0.5f) // Poke mechanic once game has started
            {
                activePlayer.pokePoints += 1; // adds points to player who is active
                zombie.totalPokes += 1; // zombie's total pokes go up by 1
                zombie.zomThreshold -= 1; // reduces zombie's threshold by 1

                

            activePlayer.scoreText.text = activePlayer.pokePoints.ToString();

               mechAnim.SetTrigger("pokeout");
               mechAud.clip = mechOut;
               mechAud.Play();
            }

            if (gameEnded && Input.GetKeyUp(KeyCode.Return))
            {

                SceneManager.LoadScene("GamePick");


            }

        
    }


    public void NextPlayer()
    {
        _activePlayer = playerList[x += 1]; // changes who active player is

        if (x == playerList.Count - 1) // if reach end of players 
        {
            x = 0; // resets to first player
        }
    }

    public void Scoring()
    {
        activePlayer.pokePoints = 0;
        activePlayer.scoreText.text = "0";


        GameObject highestScoreObject = null;
        int highestScore = 0;

        foreach (GameObject player in playerList)
        {
            if (player != playerList[playerList.Count - 1])
            {

                int y = player.GetComponent<PTZ_Players>().pokePoints;

                if (y > highestScore)
                {
                    highestScore = y;
                    highestScoreObject = player;

                }
            }
        }

       winnerText = highestScoreObject.GetComponent<PTZ_Players>().playerLabel.text + " wins!";
       
       highestScoreObject.GetComponent<PTZ_Players>().WinMode();
      
    }
}
