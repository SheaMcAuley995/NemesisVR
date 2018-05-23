using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScepterClang : MonoBehaviour {

    public float volume;
    public float speedThreshold;
    public AudioSource audio;
    public Transform headPos;

    private Vector3 lastHeadPos;
    private Vector3 headOffset = Vector3.zero;
    private Vector3 correctLocalPos;
    private Vector3 correctLocalEuler;



    private void Start()
    {
        lastHeadPos = headPos.position;
        correctLocalPos = transform.localPosition;
        correctLocalEuler = transform.localEulerAngles;
    }

    private void Update()
    {
        transform.localPosition = correctLocalPos;
        transform.localEulerAngles = correctLocalEuler;
        headOffset = headPos.position - lastHeadPos;
        lastHeadPos = headPos.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(headOffset.magnitude >= speedThreshold)
        {
            audio.PlayOneShot(audio.clip, headOffset.magnitude * volume);
        }
    }

}
