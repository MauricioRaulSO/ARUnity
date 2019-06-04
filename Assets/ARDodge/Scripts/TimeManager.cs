using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public PlayerHighScore playerHighScore;
    public AnimatedNumberField playerScore;
    public AnimatedNumberField startCount;
		public AudioSource audioSource;
		public AudioClip tickingSound;
		public AudioClip countingSound;
		public AudioClip dodgeSound;
    public UIConfigMenu configMenu;

    public float startCountTime = 5.0F;

    private float m_currentTime;
    private bool m_isCounting;

    public void PauseGame()
    {
				audioSource.PlayOneShot(tickingSound);
        Time.timeScale = 0.0F;
    }

    public void ResumeGame()
    {
				audioSource.Stop();
        Time.timeScale = 1.0F;
    }

    public void StartCounting()
    {
				audioSource.PlayOneShot(countingSound);
        m_isCounting = true;
        m_currentTime = -startCountTime;
        playerScore.score = 0;
    }

    public void StopCounting()
    {
        playerHighScore.SetHighScore((int)(m_currentTime * 10));
        m_isCounting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerHighScore) return;
        if (!playerScore) return;
        if (!startCount) return;
        if (!m_isCounting) return;

        m_currentTime += Time.deltaTime;
        startCount.score = -(int)m_currentTime + 1;

        if (m_currentTime >= 0.0F)
        {
            playerScore.score = (int)Mathf.Abs(m_currentTime * 10);
						if (!configMenu.IsRunning())
								audioSource.PlayOneShot(dodgeSound);
        		
						configMenu.StartGame();
       	}
    }
}
