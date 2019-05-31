using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHighScore : MonoBehaviour
{
    public int Highest = 0;
    public AnimatedNumberField highScore;

    public void SetHighScore(int Nscore)
    {
        if (Highest < Nscore)
        {
            Highest = Nscore;
            highScore.score = Highest;
        }
    }
}
