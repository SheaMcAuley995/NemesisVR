using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTeamIndicator : MonoBehaviour {

    public Material moon;
    public Material sun;

    public Renderer renderer;




    private void Start()
    {
        Invoke("SetMat", 0.02f);
    }

    private void SetMat()
    {
        if (transform.parent.tag == "TeamSun")
        {
            renderer.material = sun;
        }
        else
        {
            renderer.material = moon;
        }
    }

}
