using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePicker : MonoBehaviour
{
    public string[] games;
    public GameObject controlMenu;
    // Start is called before the first frame update
    void Start()
    {
        //ADD YOUR GAME TO THE games ARRAY
        //ENSURE YOUR GAME HAS BEEN ADDED TO BUILD SETTING SCENES
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Game1()
    {
        SceneManager.LoadScene(games[0]);
    }
    public void Game2()
    {
        SceneManager.LoadScene(games[1]);

    }
    public void Game3()
    {
        SceneManager.LoadScene(games[2]);

    }
    public void Game4()
    {
        SceneManager.LoadScene(games[3]);
    }
    public void Game5()
    {
        SceneManager.LoadScene(games[4]);
    }
    public void Game6()
    {
        SceneManager.LoadScene(games[5]);
    }
    public void Game7()
    {
        SceneManager.LoadScene(games[6]);
    }
    public void Game8()
    {
        SceneManager.LoadScene(games[7]);
    }

    public void Controls()
    {
        controlMenu.SetActive(true);
    }
}
