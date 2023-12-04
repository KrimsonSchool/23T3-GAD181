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

    private GameObject effectPlayer;
    private AudioSource effectAud;
    public AudioClip buttonOn;
    public AudioClip buttonSelect;
    
    // Start is called before the first frame update
    void Start()
    {
        effectPlayer = GameObject.FindWithTag("EffectPlayer");
        if (effectPlayer != null)
        {
            effectAud = effectPlayer.GetComponent<AudioSource>();
        }
        

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

        effectAud.clip = buttonOn;
        effectAud.Play();
    }

    public void VStop()
    {
        image.texture = staticImg;
        controlsText.text = null;
        vp.Stop();
        
    }

    public void Play()
    {
        effectAud.clip = buttonSelect;
        effectAud.Play();

        Destroy(GameObject.FindGameObjectWithTag("MusicPlayer"));
        SceneManager.LoadScene(gameNameNoSpaces);
    }
}
