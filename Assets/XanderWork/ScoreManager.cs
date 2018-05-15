using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    private ScoreManager instance;
    public ScoreManager Instance
    {
        get
        {
            return instance;
        }
    }

    private int scoreSun = 0;
    public int ScoreSun
    {
        get
        {
            return scoreSun;
        }
    }

    private int scoreMoon = 0;
    public int ScoreMoon
    {
        get
        {
            return scoreMoon;
        }
    }

    public int scoreToWin;

    public delegate void OnScoreIncrease(int score);
    public OnScoreIncrease onScoreSunIncrease;
    public OnScoreIncrease onScoreMoonIncrease;





    private void Awake()
    {
        instance = this;
    }

    public void AddScoreSun(int amt)
    {
        scoreSun += amt;
        if(onScoreSunIncrease != null)
        {
            onScoreSunIncrease(scoreSun);
        }
    }

    public void AddScoreMoon(int amt)
    {
        scoreMoon += amt;
        if (onScoreMoonIncrease != null)
        {
            onScoreMoonIncrease(scoreMoon);
        }
    }

}
