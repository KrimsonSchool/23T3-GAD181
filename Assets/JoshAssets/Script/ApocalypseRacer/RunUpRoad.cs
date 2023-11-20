using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class RunUpRoad : MonoBehaviour
{

    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 10;
        StartCoroutine(WaitToMove());
    }



    // have zombies wait 3 seconds before moving up the road.
    public IEnumerator WaitToMove()
    {
        yield return new WaitForSeconds(4f);
        agent.destination = new Vector3(transform.position.x + 270, transform.position.y, transform.position.z);
    }
    // Update is called once per frame
    void Update()
    {   

    }
}
