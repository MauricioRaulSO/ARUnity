using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIConfigMenu : MonoBehaviour
{
    public TimeManager timeManager;
    public ARPortalPositioning portalPositioning;
    public GameObject startMenu;
    public GameObject configButton;

    private bool isStarted;

    public void PauseGame()
    {
        Time.timeScale = 0.0F;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0F;
    }

    public void SwitchMenu()
    {
        if (!gameObject.activeSelf)
        {
            PauseGame();
        } else {
            ResumeGame();
        }
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public void ResetGame()
    {
        timeManager.StopCounting();
        portalPositioning.CreatePortal();
        ResumeGame();
        startMenu.SetActive(true);
        configButton.SetActive(false);
        gameObject.SetActive(false);
        isStarted = false;
    }

    public void StartGame()
    {
        if (isStarted) return;
        portalPositioning.StartPortal();
        startMenu.SetActive(false);
        configButton.SetActive(true);
        isStarted = true;
        gameObject.SetActive(false);
    }
}
