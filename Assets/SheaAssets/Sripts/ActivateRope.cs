using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateRope : MonoBehaviour {

    public Transform start;
    public Transform end;

    GameObject ropeNode;
    public GameObject rope;
    void Start()
    {
            Vector3 destiny = end.position;
            ropeNode = (GameObject)Instantiate(rope, transform.position, Quaternion.identity);
            ropeNode.GetComponent<RopePhysics>().destiny = destiny;
    }

}
