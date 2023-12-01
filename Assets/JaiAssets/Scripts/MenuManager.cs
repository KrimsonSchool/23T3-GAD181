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
    // Start is called before the first frame update
    void Start()
    {
        noOfRoundsSlider.Select();
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
        PlayerPrefs.SetInt("player1Score", 0);
        PlayerPrefs.SetInt("player2Score", 0);
        PlayerPrefs.SetInt("player3Score", 0);
        PlayerPrefs.SetInt("player4Score", 0);
        SceneManager.LoadScene(1);
    }


}
