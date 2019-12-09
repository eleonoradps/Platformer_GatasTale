using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate : MonoBehaviour
{
    public GameObject winPanelUI;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("vazy ta race");
        if(collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("fais le");
            ActivateWinPanel();
            Debug.Log("active le panel putain");
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
