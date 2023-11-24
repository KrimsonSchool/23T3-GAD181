using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public Animator an;
    public GameObject arrow;
    public GameObject goHere;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Win()
    {
        an.SetBool("Win", true);
        Destroy(arrow);
        Destroy(goHere);
    }
}
