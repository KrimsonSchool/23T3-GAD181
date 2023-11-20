using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateMat : MonoBehaviour
{
    public Material mat;
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
        if(Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            timer += Time.deltaTime;
        }

        if(timer > timing)
        {
            index++;
            if(index == textures.Length)
            {
                index = 0;
            }
            timer = 0;
        }

        mat.mainTexture = textures[index];
    }
}
