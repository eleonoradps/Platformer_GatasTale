using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate : MonoBehaviour
{
    public GameObject winPanelUI;
    private void OnTriggerEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if(winPanelUI.activeSelf)
            {
                ActivateWinPanel();
            }
        }
    }

    public void ActivateWinPanel()
    {
        winPanelUI.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
