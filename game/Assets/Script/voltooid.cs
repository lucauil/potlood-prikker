using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voltooid : MonoBehaviour
{
    public GameObject Voltooid;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false; 
    }
    void update(){

    }
    
    
       private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!Voltooid.activeSelf)
            {
                Time.timeScale = 0f;
                Voltooid.SetActive(true);
                Cursor.visible = true;
            }
            else
            {
                Time.timeScale = 1f;
                Voltooid.SetActive(false);
                Cursor.visible = false;

            }
        }
                
     
    } 
    public void stoppen()
    {
        Application.Quit();
    }

    public void verder()
    {
        Time.timeScale = 1f;
        Voltooid.SetActive(false);
    Cursor.visible = false;
    }

}