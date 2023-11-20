using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

public class RImgScroll : MonoBehaviour
{
    public RawImage rImg;
    public float moveX;
    public float moveY;
     Rect move;
    // Start is called before the first frame update
    void Start()
    {
        move = rImg.uvRect;
    }

    // Update is called once per frame
    void Update()
    {
        move.x += moveX;
        move.y += moveY;
        rImg.uvRect = move;
    }
}
