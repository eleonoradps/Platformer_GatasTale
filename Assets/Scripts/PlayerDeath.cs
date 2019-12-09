using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private PlayerController playerController;

    private bool playerDeath;
    [SerializeField] private GameObject deathPanelUI;

    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }
    void Update()
    {
        if(playerDeath)
        {
            PlayerDeathPanel();
        }
    }

    public void PlayerDeathPanel()
    {
        deathPanelUI.SetActive(true);
        Time.timeScale = 0f;
        playerDeath = true;
    }

}
