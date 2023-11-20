using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieRoam : MonoBehaviour
{
    // Start is called before the first frame update
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 10;
        agent.destination = new Vector3(transform.position.x, transform.position.y, transform.position.z -12);
        if (Vector3.Distance(transform.position, agent.destination) < 2)
        {
            agent.destination = new Vector3(transform.position.x + 6, transform.position.y, transform.position.z + 12);
            agent.destination = new Vector3(transform.position.x - 6, transform.position.y, transform.position.z - 12);
        }
    }



    // have zombies wait 3 seconds before moving up the road.

    // Update is called once per frame
    void Update()
    {
                  
       

    }
}
