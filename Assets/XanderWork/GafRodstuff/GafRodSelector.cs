using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GafRodSelector : MonoBehaviour {

    public GameObject goldRod;
    public GameObject silverRod;

    private void Start()
    {
        if(SceneBridge.Instance.playerTeam == TeamManager.TeamBall.Sun)
        {
            goldRod.SetActive(true);
            silverRod.SetActive(false);
        }
        else
        {
            goldRod.SetActive(false);
            silverRod.SetActive(true);
        }
    }

}
