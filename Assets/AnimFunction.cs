using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimFunction : MonoBehaviour
{
    // Start is called before the first frame update
    public string sceneName;
    public Animator animator;
    void Start()
    {
        if(PlayerPrefs.GetInt("First") == 0)
        {
            animator.enabled = true;
            PlayerPrefs.SetInt("First", 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
