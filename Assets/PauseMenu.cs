using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool pausedGame = false;
    public GameObject pauseMenuUI;
   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
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
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        pausedGame = false;
    }

    void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        pausedGame = true;
    }

    public void QuitGame()
    {
        //Debug.Log("Quit game");
        SceneManager.LoadScene("MainMenu");
    }
}
