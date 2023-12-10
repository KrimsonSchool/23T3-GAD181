using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingItems : MonoBehaviour
{
    public int itemsCollected;
    public TMPro.TextMeshProUGUI scoreText;
    public AudioSource itemPickUpSound;
    public AudioClip clipToPlay;

    private void Update()
    {
       scoreText.text = name+ " score: " + itemsCollected;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            itemPickUpSound.Play();
            itemsCollected += 1;
            other.gameObject.SetActive(false);
            FindAnyObjectByType<CureMakerGameManager>().noCollected++;
        }
    }
}
