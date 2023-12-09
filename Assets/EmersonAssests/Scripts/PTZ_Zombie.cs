using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class PTZ_Zombie : MonoBehaviour
{
    public int zomThreshold;
    public int totalPokes;

    private PTZ_GameRun gr;
    public TextMeshProUGUI status;

    private PTZ_PlayerAmount pa;

    public GameObject zombie;

    private PTZ_Timer tim;

    public GameObject exit;

    public int zomStir01_int;
    public bool zomStir01;

    public int zomStir02_int;
    public bool zomStir02;

    public AudioClip scream;
    public AudioClip stir;

    // Start is called before the first frame update
    void Start()
    {
        gr = this.gameObject.GetComponent<PTZ_GameRun>();
        pa = this.gameObject.GetComponent<PTZ_PlayerAmount>();

        zomThreshold = Random.Range(80 * pa.playerAmount, 160 * pa.playerAmount);

        tim = this.gameObject.GetComponent<PTZ_Timer>();

        zomStir01 = false; zomStir02 = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (totalPokes >= zomThreshold && !gr.gameEnded)
        {
            ZomTrigger();

        }

        zomStir01_int = zomThreshold / 2;
        

        if (totalPokes >= zomStir01_int && !zomStir01)
        {
            zomStir01 = true;
            ZombieStir();

        }

        zomStir02_int = zomThreshold / 4 * 3;

        if (totalPokes >= zomStir02_int && !zomStir02)
        {
            zomStir02 = true;
            ZombieStir();

        }

    }


    public void ZomTrigger()
    {
        Debug.Log("Zombie has woken up");
        gr.gameBegun = false;
        gr.gameEnded = true;

        tim.timerText.GetComponent<AudioSource>().Stop();

        gr.Scoring();


        zombie.GetComponent<Animator>().SetTrigger("zomTrigger");
        zombie.GetComponent<AudioSource>().clip = scream;
        zombie.GetComponent<AudioSource>().Play();
        gr.mechAnim.Play("MechArm_idle");

        exit.SetActive(true);

    }

    public void ZombieStir()
    {
        zombie.GetComponent<Animator>().SetTrigger("zomStir");
        
        zombie.GetComponent<AudioSource>().clip = stir;
        zombie.GetComponent<AudioSource>().Play();

        Debug.Log("Zombie Stirs");
       
    }
}
