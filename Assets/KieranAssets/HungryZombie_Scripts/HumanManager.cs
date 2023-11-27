
using System.Collections;
using UnityEngine;

public class HumanManager : MonoBehaviour
{
    public HungryZombiesManager zombiesManager;
    public int humanID = 0;

    [SerializeField] private GameObject humanToDestroy;
    [SerializeField] private GameObject humanTwoToDestroy;
    //[SerializeField] private GameObject humanGoPop;
    [SerializeField] private ParticleSystem humanGoPop;
    

    // Start is called before the first frame update
    void Start()
    {
        
        humanToDestroy.SetActive(true);
        humanTwoToDestroy.SetActive(true);

        humanToDestroy.GetComponent<HungryZombiesManager>();
        humanTwoToDestroy.GetComponent<HungryZombiesManager>();





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
                transform.Translate(0, 0, 5f * Time.deltaTime);


                break;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(humanID == 1 && other.CompareTag("Player"))
        {
            Instantiate(humanGoPop, transform.position, Quaternion.identity);
            humanToDestroy.SetActive(false);
            humanGoPop.Stop(humanGoPop);

        }
       if (humanID == 2 && other.CompareTag("Player"))
        {
            Instantiate(humanGoPop, transform.position, Quaternion.identity);
            humanTwoToDestroy.SetActive(false);
            humanGoPop.Stop(humanGoPop);
        }
        
    }

}
