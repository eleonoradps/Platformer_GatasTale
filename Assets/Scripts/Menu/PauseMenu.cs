using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool pausedGame = false;
    [SerializeField] private GameObject pauseMenuUI;
   
    public GameObject PauseMenuUI
    {
        get => pauseMenuUI;
        set => pauseMenuUI = value;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(pausedGame)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        pausedGame = false;
    }

    private void PauseGame()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        pausedGame = true;
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
