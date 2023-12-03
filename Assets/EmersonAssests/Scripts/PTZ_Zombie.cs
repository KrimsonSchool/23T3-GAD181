using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        gr = this.gameObject.GetComponent<PTZ_GameRun>();
        pa = this.gameObject.GetComponent<PTZ_PlayerAmount>();

        zomThreshold = Random.Range(80 * pa.playerAmount, 160 * pa.playerAmount);

        tim = this.gameObject.GetComponent<PTZ_Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (totalPokes >= zomThreshold && !gr.gameEnded)
        {
            ZomTrigger();

        }


    }


    public void ZomTrigger()
    {
        Debug.Log("Zombie has woken up");
        gr.gameBegun = false;
        gr.gameEnded = true;



        gr.Scoring();

       // Destroy(gr.hand);

        //tim.timerText.GetComponent<AudioSource>().Stop();

        zombie.GetComponent<Animator>().SetTrigger("zomTrigger");
        gr.mechAnim.Play("MechArm_idle");

        exit.SetActive(true);

    }
}
