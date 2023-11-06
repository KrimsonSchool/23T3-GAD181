using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMovement : MonoBehaviour
{
    public GameObject[] Players;
    public int[] dead;
    public int playersAlive;
    Vector3 playerspos;
    public GameObject GameOverPrompt;
    // Start is called before the first frame update
    void Start()
    {
        playersAlive = PlayerPrefs.GetInt("Players");
        dead = new int[playersAlive];
        GameOverPrompt.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < dead.Length; i++)
        {
            if (Players[i].GetComponent<PlayerHealth>().health <= 0 && dead[i] != 1)
            {
                dead[i] = 1;
                playersAlive--;
            }
            if (dead[i] != 1)
            {
                playerspos += Players[i].transform.position;
            }
        }
        transform.position = (playerspos / playersAlive) + new Vector3(5, 17, -25);
        playerspos = Vector3.zero;
        if (playersAlive == 0)
        {
            GameOverPrompt.SetActive(true);
            StartCoroutine(GameOver());
        }
    }
    public IEnumerator GameOver()
    {
        yield return new WaitForSeconds(3f);
        GameOverPrompt.SetActive(false);
        SceneManager.LoadScene("GamePick");
    }
    

    
}







