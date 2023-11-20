using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanManager : MonoBehaviour
{
    public HungryZombiesManager zombiesManager;
    public int humanID = 0;

    [SerializeField] private GameObject humanToDestroy;
    [SerializeField] private GameObject humanTwoToDestroy;

    public HungryZombiesManager hungryZombiesManager;

    // Start is called before the first frame update
    void Start()
    {
        humanToDestroy.SetActive(true);
        humanTwoToDestroy.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        switch (humanID)
        {
            case 1:
            transform.Translate(0, 0, 5f * Time.deltaTime);
            

                break;

            case 2:
                transform.Translate(0, 0, -5f * Time.deltaTime);


                break;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(humanID == 1 && other.CompareTag("Player"))
        {
            humanToDestroy.SetActive(false);
        }
       if (humanID == 2 && other.CompareTag("Player"))
        {
            humanTwoToDestroy.SetActive(false);
        }
        
    }

}
