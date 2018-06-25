using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DerpLerp : MonoBehaviour {

    public Transform target;
    public float speed;

	void Update () {
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);
	}
}
