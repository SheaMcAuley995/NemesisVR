using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiHover : MonoBehaviour {



    public Rigidbody rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


}
