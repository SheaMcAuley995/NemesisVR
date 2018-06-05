using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TeamManager : MonoBehaviour {
    public enum TeamBall { Moon, Sun, NoTeam };

    public int capacity;

    

    public static List<GameObject> TeamSun;
    private bool hasBall = false;
    public static List<GameObject> TeamMoon;

}
