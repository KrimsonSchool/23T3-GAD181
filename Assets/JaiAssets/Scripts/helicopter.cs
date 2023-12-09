using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class helicopter : MonoBehaviour
{
    [HideInInspector]public int winningPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Back()
    {
        winningPlayer++;
        print(winningPlayer);
        PlayerPrefs.SetInt("player" + winningPlayer + "Score", PlayerPrefs.GetInt("player" + winningPlayer + "Score") + 50);
        SceneManager.LoadScene("GamePick");
    } 
}
