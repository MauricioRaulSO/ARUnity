using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIConfigMenu : MonoBehaviour
{
    public TimeManager timeManager;
    public ARPortalPositioning portalPositioning;
    public ARPlaceInGroundAt delimiterPositioning;
    public GameObject startMenu;
    public GameObject configButton;

    private bool isStarted;

		public bool IsRunning() 
		{
				return isStarted;
		}

    public void SwitchMenu()
    {
        if (!gameObject.activeSelf)
        {
            timeManager.PauseGame();
        } else {
						timeManager.ResumeGame();
        }
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public void ResetGame()
    {
        timeManager.StopCounting();
        portalPositioning.CreatePortal();
        timeManager.ResumeGame();
        startMenu.SetActive(true);
        configButton.SetActive(false);
        gameObject.SetActive(false);
        delimiterPositioning.isUpdating = true;
        isStarted = false;
    }

    public void StartGame()
    {
        if (isStarted) return;
        portalPositioning.StartPortal();
        startMenu.SetActive(false);
        configButton.SetActive(true);
        delimiterPositioning.isUpdating = false;
        isStarted = true;
        gameObject.SetActive(false);
    }
}
