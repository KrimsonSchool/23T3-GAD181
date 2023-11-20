using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungryZombiesManager : MonoBehaviour
{

    public GameObject Kieran_humanToSpawn;
    public GameObject Kieran_humanToSpawnTwo;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnHuman", 1, 5);
    }

    
    void SpawnHuman()
    {
        Vector3 randomPosition = new Vector3(
        Random.Range(-1.54f, 1.794f), 1.2f, -4.5f);
        Vector3 otherRandomPosition = new Vector3(Random.Range(-1.54f, 1.794f), 1.2f, 10.5f);

        Instantiate(Kieran_humanToSpawn, randomPosition, Quaternion.identity);
        Instantiate(Kieran_humanToSpawnTwo, otherRandomPosition, Quaternion.identity);
    }



}
