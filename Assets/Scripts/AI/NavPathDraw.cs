using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(LineRenderer))]
public class NavPathDraw : MonoBehaviour {

    [SerializeField]
    private NavMeshAgent navAgent;

    private LineRenderer lr;
	// Use this for initialization
	void Start () {
        lr = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(navAgent.hasPath)
        {
            lr.positionCount = navAgent.path.corners.Length;
            lr.SetPositions(navAgent.path.corners);
            lr.enabled = true;
        }
        else
        {
            lr.enabled = false;
        }
	}
}
