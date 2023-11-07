using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Achtergrond : MonoBehaviour
{
    private float length, startpos;
    public GameObject Camera;
    public float ParalaxEffect;

    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        float temp = (Camera.transform.position.x * (1 - ParalaxEffect));
        float dist = (Camera.transform.position.x * ParalaxEffect);
        transform.position = new Vector3(startpos + dist,transform.position.y,transform.position.z);
        if(temp >startpos+length) 
        { 
            startpos += length;
        }
        else if(temp < startpos - length) 
        {
            startpos -= length;
        }
    }
}