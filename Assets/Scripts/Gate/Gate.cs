using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate : MonoBehaviour
{
    [SerializeField] private GameObject winPanelUI;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            ActivateWinPanel();
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
