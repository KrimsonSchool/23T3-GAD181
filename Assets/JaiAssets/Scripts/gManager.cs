using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gManager : MonoBehaviour
{
    public Player[] players;


    public TMPro.TextMeshProUGUI mPro;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void canMove()
    {
        foreach (Player p in players)
        {
            p.move();
        }
    }

    public void win()
    {
    }
}
