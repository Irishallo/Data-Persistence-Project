using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Brick : MonoBehaviour
{
    public UnityEvent<int> onDestroyed;
    
    public int PointValue;
    public Color lightGreen;
    public Color lightYellow;
    public Color lightBlue;
    public Color lightRed;

    void Start()
    {
        var renderer = GetComponentInChildren<Renderer>();

        MaterialPropertyBlock block = new MaterialPropertyBlock();
        switch (PointValue)
        {
            case 1 :
                block.SetColor("_BaseColor", lightGreen);
                break;
            case 2:
                block.SetColor("_BaseColor", lightYellow);
                break;
            case 5:
                block.SetColor("_BaseColor", lightBlue);
                break;
            default:
                block.SetColor("_BaseColor", lightRed);
                break;
        }
        renderer.SetPropertyBlock(block);
    }

    private void OnCollisionEnter(Collision other)
    {
        onDestroyed.Invoke(PointValue);
        
        //slight delay to be sure the ball have time to bounce
        Destroy(gameObject, 0.2f);
    }
}
