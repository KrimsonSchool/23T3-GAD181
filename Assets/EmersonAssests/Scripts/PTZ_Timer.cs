using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PTZ_Timer : MonoBehaviour
{
    public float targetTime = 5.5f;
    private PTZ_GameRun gr;




    public TextMeshProUGUI timerText;
    private float displayTime;

    private AudioSource tickAud;



    // Start is called before the first frame update
    void Start()
    {

        gr = this.gameObject.GetComponent<PTZ_GameRun>();
        tickAud = timerText.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (gr.gameBegun && !gr.gameEnded)
        {
            targetTime -= Time.deltaTime;
            displayTime = Mathf.Round(targetTime);


        }


        if (targetTime <= 0.5f)
        {
            timerText.text = "Time's Up!";
            timerText.fontSize = 30;
           // gr.hand.transform.position = new UnityEngine.Vector3(-0.88f, 2f, gr.hand.transform.position.z);
           // gr.hand.transform.localScale = new UnityEngine.Vector2(0.64f, gr.hand.transform.localScale.y);

           // var anim = gr.activePlayer.GetComponent<PTZ_Players>().goblin.GetComponent<Animator>();
           // string animationName = "p" + gr.activePlayer.GetComponent<PTZ_Players>().playerNo + "_still";
           // anim.Play(animationName);



        }
        else if (gr.gameEnded)
        {
            timerText.text = gr.winnerText;
            timerText.fontSize = 30;
        }
        else if (!gr.gameBegun && !gr.gameBegun)
        {
            timerText.text = "Poke!";
            timerText.fontSize = 30;
        }
        else
        {
            timerText.text = displayTime.ToString();
            timerText.fontSize = 36;

        }


        if (targetTime <= -0.49f)
        {
            TimeEnded();
        }


    }

    public void TimeEnded()
    {
        targetTime = 5.5f;
        gr.NextPlayer();
        tickAud.Play();
    }
}
