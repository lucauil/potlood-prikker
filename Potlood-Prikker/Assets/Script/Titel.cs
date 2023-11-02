using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Titel : MonoBehaviour
{
    public GameObject Text;
    private float timer;
    public float SPEEED;
    // Update is called once per frame
    void Update()
    {
        BlinkingText();
        timer += Time.deltaTime * SPEEED;
        Debug.Log(timer);

        if (Input.GetKeyUp(KeyCode.KeypadEnter))
        {
            SceneManager.LoadScene("HoofdMenu");
        }
    }

    
        
    public void BlinkingText()
    {
        if (timer < 0.5f)
        {
            Text.SetActive(false);
        }

        if(timer > 0.5f)
        {
            Text.SetActive(true);
            
        }
        if(timer >= 1f)
        {
            timer = 0f;
        }
    }
}
