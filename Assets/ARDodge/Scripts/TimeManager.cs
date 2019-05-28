using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public PlayerScore playerScore;
    private float m_currentTime;

    public void Start()
    {
        m_currentTime = 0.0F;
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerScore) return;

        m_currentTime += Time.deltaTime;
        playerScore.score = (int)m_currentTime;
    }
}
