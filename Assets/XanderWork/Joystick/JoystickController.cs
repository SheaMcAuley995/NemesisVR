using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Valve.VR.InteractionSystem
{
    public class JoystickController : MonoBehaviour
    {

        public JoystickHandle joystickHandle;



        private void Awake()
        {
            joystickHandle.joystickControlUpdate += JoystickUpdate;
        }

        public void JoystickUpdate(Hand hand)
        {
            //transform.LookAt()
            //(hand.transform);
            Vector3 offset = (hand.transform.position - transform.position);
            Debug.Log(offset);
            float rollOffset = Vector2.Angle(new Vector2(offset.x, offset.y), Vector2.up);
            transform.eulerAngles -= Vector3.forward * rollOffset;
            //transform.eulerAngles += Vector3.right * 90;
           // transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
        }

        public void Rotate(float roll, float pitch)
        {
            transform.eulerAngles += Vector3.forward * roll;
            transform.eulerAngles += Vector3.right * pitch;
        }

    }
}

