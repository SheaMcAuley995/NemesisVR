using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabBall : MonoBehaviour {


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ball")
        {
            HoverBall.Instance.HoverToPos = this.transform;
        }
    }



}
