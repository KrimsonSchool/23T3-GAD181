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
        agent.destination = new Vector3(transform.position.x + Random.Range(-5, 5), transform.position.y, transform.position.z + Random.Range(-5, 5));
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, agent.destination) < 2)
        {
            agent.destination=new Vector3(transform.position.x+Random.Range(-5,5),transform.position.y,transform.position.z + Random.Range(-5, 5));
        }
    }
}
