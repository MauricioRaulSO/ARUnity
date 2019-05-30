using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHighScore : MonoBehaviour
{
    public int Highest;

    void setHighScore(int Nscore)
    {
        if (Highest < Nscore)
        {
            Highest = Nscore;
        }
    }
}
