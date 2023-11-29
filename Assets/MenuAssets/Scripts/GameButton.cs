using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;

public class GameButton : MonoBehaviour
{
    public string gameNameNoSpaces;
    
    public Texture staticImg;
    public Texture dynamicImg;
    public TextMeshProUGUI controlsText;
    [TextArea(8, 16)]
    public string inputs;


    public GameObject gamePreview;
    private VideoPlayer vp;
    private RawImage image;
    // Start is called before the first frame update
    void Start()
    {
        vp = gamePreview.GetComponent<VideoPlayer>();

        image = gamePreview.GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VPlay()
    {
        image.texture = dynamicImg;
        controlsText.text = inputs;
        vp.Play();
    }

    public void VStop()
    {
        image.texture = staticImg;
        controlsText.text = null;
        vp.Stop();
        
    }

    public void Play()
    {
        SceneManager.LoadScene(gameNameNoSpaces);
    }
}
