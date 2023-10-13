using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.destination = new Vector3 (transform.position.x + Random.Range(-10f, 10f), transform.position.y, transform.position.z + Random.Range(-10f, 10f));
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, agent.destination) < 2)
        {
            agent.destination = new Vector3(transform.position.x + Random.Range(-10f, 10f), transform.position.y, transform.position.z + Random.Range(-10f, 10f));
        }
    }
}
