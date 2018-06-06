using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lookat : MonoBehaviour {

    public Transform target;

    private void Start()
    {
        if(target == null)
        {
            target = GameObject.FindGameObjectWithTag("Goal").transform;
        }
    }

    // Update is called once per frame
    void Update () {
        transform.LookAt(target);
	}
}
