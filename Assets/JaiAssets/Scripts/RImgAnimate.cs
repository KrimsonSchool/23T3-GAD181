using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RImgAnimate : MonoBehaviour
{
    public RawImage rImg;
    public Texture[] textures;
    public float timing;
    float timer;
    int index;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timing)
        {
            index++;
            if (index == textures.Length)
            {
                index = 0;
            }
            timer = 0;
        }

        rImg.texture = textures[index];
    }
}
