using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum alphaValue
{
    SHRINKING,
    GROWING
}

public class Titel : MonoBehaviour
{
    public alphaValue currentAlpaValue;
    public float CommentMinAlpha;
    public float CommentMaxAlpha;
    public float CommentCurrentAlpha;

    public GameObject Text;
    private float timer;

    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        BlinkingText();
        timer += Time.deltaTime;
        Debug.Log(timer);
    }

    
        
    public void BlinkingText()
    {
        if(timer <= 0.5f)
        {
            Text.SetActive(false);
        }

        if(timer >= 0.5f)
        {
            Text.SetActive(true);
            
        }
        if(timer >= 1f)
        {
            timer = 0f;
        }
    }
}
