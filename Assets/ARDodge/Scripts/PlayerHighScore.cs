using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHighScore : MonoBehaviour
{
    public int Highest = 0;
    public AnimatedNumberField highScore;

    void setHighScore(int Nscore)
    {
        if (Highest < Nscore)
        {
            Highest = Nscore;
            highScore.score = Highest;
        }
    }
}
