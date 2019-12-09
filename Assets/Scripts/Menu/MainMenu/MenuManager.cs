using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private bool goToCredits = false;
    private GameObject creditsPanelUI;

    private void Update()
    {
        if(goToCredits)
        {
            GoToCredits();
        }
        else
        {
            GoBackToMenu();
        }
    }
    public void GoToCredits()
    {
        creditsPanelUI.SetActive(true);
        goToCredits = true;
    }

    public void GoBackToMenu()
    {
        creditsPanelUI.SetActive(false);
        goToCredits = false;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
