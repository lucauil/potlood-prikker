using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{
    Camera camera;
    public GameObject drawline;

    LineRenderer lineRenderer;

    Vector2 Lastposition;

    void Drawing()
    {
        if(Input.GetKeyDown(KeyCode.Space))    
        { 
        
        }
    }

    void CreatBrush()
    {
        GameObject brushInstance = Instantiate(drawline);
        lineRenderer =brushInstance.GetComponent<LineRenderer>();

        Vector2 Point = camera.ScreenToWorldPoint(Input.mousePosition);
    }

}
