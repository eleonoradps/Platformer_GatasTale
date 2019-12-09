using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsPanel : MonoBehaviour
{
     private bool creditsPanel = false;
    public GameObject creditsPanelUI;

    void Update()
    {
        if(creditsPanel)
        {
            ActivateCreditsPanel();
        }
        else
        {
            QuitCredits();
        }
    }

    public void ActivateCreditsPanel()
    {
        creditsPanelUI.SetActive(true);
        creditsPanel = true;
    }

    public void QuitCredits()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
