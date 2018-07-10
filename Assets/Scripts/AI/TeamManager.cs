using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TeamManager : MonoBehaviour {
    public enum TeamBall { Moon, Sun, NoTeam };

    //public int capacity;
    private bool hasBall = false;
    public static TeamBall ballStatus;
    public AiController[] AIBeetles;
    public Transform[] SunSpawn;
    public Transform[] MoonSpawn;
    public GameObject playerBeetle;

    [SerializeField]
    public List<GameObject> TeamSun;
    [SerializeField]
    public List<GameObject> TeamMoon;

    public void Start()
    {
        if(SceneBridge.Instance.playerTeam == TeamBall.Moon)
        {
            TeamMoon.Add(playerBeetle);
            TeamSun.Add(AIBeetles[0].gameObject);
            AIBeetles[0].myTeam = TeamBall.Sun;
            AIBeetles[0].tag = "TeamSun";
        }
        else if (SceneBridge.Instance.playerTeam == TeamBall.Sun)
        {
            TeamSun.Add(playerBeetle);
            TeamMoon.Add(AIBeetles[0].gameObject);
            AIBeetles[0].myTeam = TeamBall.Moon;
            AIBeetles[0].tag = "TeamMoon";
        }

        for(int i = 1; i < AIBeetles.Length; i += 2)
        {
            TeamSun.Add(AIBeetles[i].gameObject);
            AIBeetles[i].myTeam = TeamBall.Sun;
            AIBeetles[i].tag = "TeamSun";
            TeamMoon.Add(AIBeetles[i + 1].gameObject);
            AIBeetles[i + 1].myTeam = TeamBall.Moon;
            AIBeetles[i + 1].tag = "TeamMoon";
        }

    }
}
