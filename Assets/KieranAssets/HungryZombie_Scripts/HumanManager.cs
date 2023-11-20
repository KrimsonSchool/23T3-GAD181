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

    public MiniGameTwoPlayerController playerAccess;

    // Start is called before the first frame update
    void Start()
    {
        humanToDestroy.SetActive(true);
        humanTwoToDestroy.SetActive(true);

        humanToDestroy.GetComponent<HungryZombiesManager>();
        humanToDestroy.GetComponent <MiniGameTwoPlayerController>();

        humanTwoToDestroy.GetComponent <HungryZombiesManager>();
        humanTwoToDestroy.GetComponent <MiniGameTwoPlayerController>();


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
            if (playerAccess.zombie)
            {
                zombiesManager.UpdateScoreTextOne();
            }
            else if (playerAccess.zombie)
            {
                zombiesManager.UpdateScoreTextTwo();
            }
            else if (playerAccess.zombie)
            {
                zombiesManager.UpdateScoreTextThree();
            }
            else if (playerAccess.zombie)
            {
                zombiesManager.UpdateScoreTextFour();
            }
        }
       if (humanID == 2 && other.CompareTag("Player"))
        {
            humanTwoToDestroy.SetActive(false);
            if (playerAccess.zombie)
            {
                zombiesManager.UpdateScoreTextOne();
            }
            else if (playerAccess.zombie)
            {
                zombiesManager.UpdateScoreTextTwo();
            }
            else if (playerAccess.zombie)
            {
                zombiesManager.UpdateScoreTextThree();
            }
            else if (playerAccess.zombie)
            {
                zombiesManager.UpdateScoreTextFour();
            }
        }
        
    }

}
