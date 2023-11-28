using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class ZombieRoam : MonoBehaviour
{
    // Start is called before the first frame update
    public NavMeshAgent agent;
    NavMeshPath navMeshPath;
    public float max;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 10;
        PickDest();
        navMeshPath = new NavMeshPath();
    }



    // have zombies wait 3 seconds before moving up the road.

    // Update is called once per frame
    void Update()
    {
                  
       if(Vector3.Distance(transform.position, agent.destination) < 2)
        {
            PickDest();
        }

        agent.CalculatePath(agent.destination, navMeshPath);
        if (navMeshPath.status != NavMeshPathStatus.PathComplete)
        {
            PickDest();
        }

    }

    public void PickDest()
    {
        agent.destination = new Vector3(transform.position.x+Random.Range(-max, max), transform.position.y, transform.position.z + Random.Range(-max, max));
    }
}
