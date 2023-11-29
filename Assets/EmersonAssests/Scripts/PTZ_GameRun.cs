using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
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

   // public GameObject hand;
    public GameObject musicPlayer;

    public AudioClip[] pokeSound;
    public AudioSource effectAud;

    

    public string winnerText;


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

        effectAud = this.GetComponent<AudioSource>();


        


    }


    // Update is called once per frame
    void Update()
    {
        _activePlayer = playerList[x]; // constantly checks who the active player is
        activePlayer = _activePlayer.GetComponent<PTZ_Players>(); // makes a player the active player

        if (Input.GetKeyDown(KeyCode.Space) && !gameBegun && !gameEnded) // starts game and timer
        {
            gameBegun = true;
            //timer.timerText.GetComponent<AudioSource>().Play();

        }

       // if (Input.GetKeyDown(KeyCode.Space) && !gameEnded)
       // {
           // hand.transform.position = new UnityEngine.Vector3(-0.88f, 1.27f, hand.transform.position.z); // hand in
            //hand.transform.localScale = new UnityEngine.Vector2(0.44f, hand.transform.localScale.y);

           // if (timer.targetTime >= 0.5f)

           // {
           //     effectAud.clip = pokeSound[UnityEngine.Random.Range(0, pokeSound.Length)];
           //     effectAud.Play();
           // }
       // }



        if (Input.GetKeyUp(KeyCode.Space) && gameBegun && timer.targetTime >= 0.5f) // Poke mechanic once game has started
        {
            activePlayer.pokePoints += 1; // adds points to player who is active
            zombie.totalPokes += 1; // lions total pokes go up by 1
            zombie.zomThreshold -= 1; // reduces lion's threshold by 1

            activePlayer.scoreText.text = activePlayer.pokePoints.ToString();

           // hand.transform.position = new UnityEngine.Vector3(-0.88f, 2f, hand.transform.position.z); // hand out
           // hand.transform.localScale = new UnityEngine.Vector2(0.64f, hand.transform.localScale.y);

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
