using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickHandle : MonoBehaviour {

    public Renderer renderer;
    public Material normalMat;
    public Material touchingMat;
    public Material holdingMat;



    private void Start()
    {
        renderer.material = normalMat;
    }



}
