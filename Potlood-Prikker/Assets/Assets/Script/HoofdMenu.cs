using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HoofdMenu : MonoBehaviour
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
        SceneManager.LoadScene("Kleur_Selectie");
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
}
