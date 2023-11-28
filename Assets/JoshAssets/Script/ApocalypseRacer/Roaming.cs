using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Roaming : MonoBehaviour
{
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        // make the zombie choose a random location on the x and z axis to move to. 
        agent.destination = new Vector3(transform.position.x + Random.Range(-5, 5), transform.position.y, transform.position.z + Random.Range(-5, 5));
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        // make the zombie choose a random location on the x and z axis to move to  and then change location after reaching its destination.
        if (Vector3.Distance(transform.position, agent.destination) < 2)
        {
            agent.destination=new Vector3(transform.position.x+Random.Range(-5,5),transform.position.y,transform.position.z + Random.Range(-5, 5));
        }
    }
}
