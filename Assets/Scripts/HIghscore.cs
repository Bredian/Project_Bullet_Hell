using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class HIghscore
{
    public int highScore;
    public HIghscore()
    {
        highScore = ObjectivePoint.score;
    }

}
