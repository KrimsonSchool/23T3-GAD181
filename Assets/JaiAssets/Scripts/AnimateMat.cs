using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateMat : MonoBehaviour
{
    public bool loop;
    public Material mat;
    public Texture[] textures;
    public float timing;
    float timer;
    int index;
    public bool alternate;
    public bool alt;
    public Texture[] altTexture;
    public float altTiming;
    public bool altLoop;
    // Start is called before the first frame update
    void Start()
    {
        mat = new Material(mat);
        GetComponentInChildren<MeshRenderer>().material = mat;
    }

    // Update is called once per frame
    void Update()
    {
        if (!alternate || !alt)
        {
            timer += Time.deltaTime;

            if (timer > timing)
            {
                index++;
                if (index == textures.Length)
                {
                    if (loop)
                    {
                        index = 0;
                    }
                    else
                    {
                        index--;
                    }
                }
                timer = 0;
            }

            mat.mainTexture = textures[index];
        }
        else
        {
            timer += Time.deltaTime;

            if (timer > altTiming)
            {
                index++;
                if (index == altTexture.Length)
                {
                    if(altLoop)
                    {

                        index = 0;
                    }
                    else
                    {
                        index--;
                    }
                }
                timer = 0;
            }

            mat.mainTexture = altTexture[index];
        }
        
    }
}
