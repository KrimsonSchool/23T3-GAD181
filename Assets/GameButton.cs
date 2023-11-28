using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class GameButton : MonoBehaviour
{
    public string gameName;
    public RawImage image;
    public Texture staticImg;
    public Texture dynamicImg;
    public TMPro.TextMeshProUGUI controlsText;
    [TextArea(8, 16)]
    public string inputs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VPlay()
    {
        image.texture = dynamicImg;
        controlsText.text = gameName+":\n\n"+ inputs;
    }

    public void VStop()
    {
        image.texture = staticImg;
    }

    public void Play()
    {
        SceneManager.LoadScene(gameName);
    }
}
