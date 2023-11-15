using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kleur : MonoBehaviour
{
    public GameObject Red;
    public GameObject Blue;
    public GameObject Green;

    public bool Timer_When_Chosen;
    public float timer;

    public static bool Red_ON;
    public static bool Green_ON;
    public static bool Blue_ON;
    private static bool Chosen_Color;

    public static bool Scene_Loaded;
   
/*    public GameObject Input_doorgaan;*/
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetSceneByBuildIndex(1).IsValid())
        {
            Red_ON = false;
            Blue_ON = false;
            Green_ON = false;
            Chosen_Color = false;
            Scene_Loaded = false;
            Timer_When_Chosen = false;
            timer = 0;
            Time.timeScale = 1; 
        }       
    }

    // Update is called once per frame
    void Update()
    {
/*        Debug.Log(Time.timeScale);*/
        if(Chosen_Color == false) 
        {
            if (Input.GetKey(KeyCode.B))
            {
                Blue_ON = true;
                
            }
            if (Input.GetKey(KeyCode.R))
            {
                Red_ON = true;
            }
            if (Input.GetKey(KeyCode.G))
            {
                Green_ON = true;
            }
        }
        if(Chosen_Color == true) 
        {
            Timer_When_Chosen = true;

            if (Scene_Loaded == false)
            {
                if (timer >= 3)
                {     
                    SceneManager.LoadScene("Level_1");
                    Scene_Loaded = true;
                }
            }

          
        }
        if(Timer_When_Chosen == true) 
        {
            timer += Time.deltaTime;
        }
        if (Blue_ON == true)
        {
            Green.SetActive(false);
            Red.SetActive(false);
            Blue.SetActive(true);
            Chosen_Color = true;
        }
        if (Red_ON == true)
        {
            Green.SetActive(false);
            Red.SetActive(true);
            Blue.SetActive(false);
            Chosen_Color = true;
        }
        if (Green_ON == true)
        {
            Green.SetActive(true);
            Red.SetActive(false);
            Blue.SetActive(false);
            Chosen_Color = true;
        }
    }
}
