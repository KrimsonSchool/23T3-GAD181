using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePicker : MonoBehaviour
{
    public string[] games;
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
}
