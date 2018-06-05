using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBridge {

    private static SceneBridge instance;
    public static SceneBridge Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new SceneBridge();
            }
            return instance;
        }
    }



    public GameObject spellPrefab;
    public GameObject staffSpellEffectPrefab;
    public TeamManager.TeamBall playerTeam;

}
