﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {

    private static ScoreManager instance;
    public static ScoreManager Instance
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

    public float fadeToBlackDuration;
    public string menuSceneName;

    private bool gameOver = false;





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

    public void CheckGameOver()
    {
        if(!gameOver && scoreSun >= scoreToWin || scoreMoon >= scoreToWin)
        {
            gameOver = true;
            SteamVR_Fade.Start(Color.black, fadeToBlackDuration);
            Invoke("GoToMenu", fadeToBlackDuration);
        }
    }

    private void GoToMenu()
    {
        SceneManager.LoadSceneAsync(menuSceneName);
    }

}
