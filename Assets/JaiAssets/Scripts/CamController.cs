using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public GameObject[] players;
    Vector3 pos;
    public GameObject start;
    float distToStart;
    GameObject furthest;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distToStart = Mathf.Infinity;

        for (int i = 0; i < players.Length; i++)
        {
            pos += players[i].transform.position;

            if (Vector3.Distance(players[i].transform.position, start.transform.position) < distToStart)
            {
                distToStart = Vector3.Distance(players[i].transform.position, start.transform.position);
                furthest = players[i];
            }
        }

        transform.position = ( pos / players.Length) + new Vector3(0, 5.77f * players.Length, -2.24f);
        transform.position = new Vector3(pos.x/players.Length, pos.y/players.Length + 5.8f * players.Length, furthest.transform.position.z - 2.24f * players.Length);
        print(pos);

        pos = Vector3.zero;
    }
}
