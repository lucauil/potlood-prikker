using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class hoofdmenu : MonoBehaviour
{
    public GameObject Optiemenu;
    // Start is called before the first frame update
    public void QuitMenu()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void CreditsGame()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Opties()
    {
        Optiemenu.SetActive(true);
    }

    public void Terug()
    {
        Optiemenu.SetActive(false);
    }

    public void Hoofdmenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
