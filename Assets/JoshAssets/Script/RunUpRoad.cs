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
        agent.speed = 8;
    }

   

    // Update is called once per frame
    void Update()
    {
        agent.destination=new Vector3(transform.position.x+10,transform.position.y,transform.position.z);
    }
}
