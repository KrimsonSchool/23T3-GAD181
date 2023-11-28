using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatScroll : MonoBehaviour
{
    public Material mat;
    Vector2 scrollDir;
    public float scrollX;
    public float scrollY;
    public float max;
    // Start is called before the first frame update
    void Start()
    {
        mat.SetTextureOffset("_BaseColorMap", Vector2.zero);
    }

    // Update is called once per frame
    void Update()
    {
        scrollDir += new Vector2(scrollX*Time.deltaTime, scrollY * Time.deltaTime);
        mat.SetTextureOffset("_BaseColorMap", scrollDir);

        if(scrollDir.x > max ||  scrollDir.y > max || scrollDir.x < -max || scrollDir.y < -max)
        {
            scrollDir = Vector2.zero;
        }
    }
}
