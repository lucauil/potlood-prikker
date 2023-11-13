using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kleur : MonoBehaviour
{
    public GameObject Red;
    public GameObject Blue;
    public GameObject Green;

    

    public static bool Red_ON;
    public static bool Green_ON;
    public static bool Blue_ON;
    private static bool Chosen_Color;

    public static bool Scene_Loaded;
   
/*    public GameObject Input_doorgaan;*/
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetSceneByBuildIndex(2).IsValid())
        {
            Red_ON = false;
            Blue_ON = false;
            Green_ON = false;
            Chosen_Color = false;
            Scene_Loaded = false;
        }
            
    }

    // Update is called once per frame
    void Update()
    {
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
            if (Scene_Loaded == false)
            {
                if (Input.GetKey(KeyCode.Backspace))
                {     
                    SceneManager.LoadScene("Level_1");
                    Scene_Loaded = true;
                }
            }

          
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
