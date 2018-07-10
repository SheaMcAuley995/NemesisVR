using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToBeetle : MonoBehaviour {

    public Transform beetle;



    private void Update()
    {
        transform.position = beetle.position;
        transform.eulerAngles = new Vector3(0, beetle.eulerAngles.y, 0);
    }

}
