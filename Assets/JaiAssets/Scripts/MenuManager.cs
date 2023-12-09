using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Slider noOfRoundsSlider;
    public TMPro.TextMeshProUGUI noOfRoundsText;
    int noOfRounds;


    

    public GameObject musicPlayer;
    public GameObject effectPlayer;


    private void Awake()
    {
        if (GameObject.FindGameObjectWithTag("MusicPlayer") == null)
        {
            Instantiate(musicPlayer, new Vector3(0f, 0f, 0f), Quaternion.identity);
        }

        if (GameObject.FindGameObjectWithTag("EffectPlayer") == null)
        {
            Instantiate(effectPlayer, new Vector3(0f, 0f, 0f), Quaternion.identity);
        }

        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("MusicPlayer"));
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("EffectPlayer"));
    }

    // Start is called before the first frame update

    void Start()
    {

        PlayerPrefs.SetInt("First", 0);
        noOfRoundsSlider.Select();

        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        noOfRounds = Mathf.RoundToInt(noOfRoundsSlider.value);
        noOfRoundsText.text = noOfRounds.ToString();
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("NoOfRounds", noOfRounds);
        PlayerPrefs.SetInt("currentRound", 0);
        PlayerPrefs.SetInt("player1Score", 0);
        PlayerPrefs.SetInt("player2Score", 0);
        PlayerPrefs.SetInt("player3Score", 0);
        PlayerPrefs.SetInt("player4Score", 0);
        
    }

  
}
