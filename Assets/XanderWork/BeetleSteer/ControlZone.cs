using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Valve.VR.InteractionSystem
{
    [RequireComponent(typeof(Interactable))]
    public class ControlZone : MonoBehaviour
    {

        public VehicleController vehicle;
        public float baseForwardSpeed;
        public float forwardForce;
        public float rotationForce;

        [Header("PROTOTYPING")]
        public Renderer renderer;
        public Material normalMat;
        public Material touchingMat;



        private Hand controlHand = null;



        private void Start()
        {
            renderer.material = normalMat;
        }

        private void OnHandHoverBegin(Hand hand)
        {
            if (controlHand == null)
            {
                renderer.material = touchingMat;
                controlHand = hand;
            }
        }

        private void OnHandHoverEnd(Hand hand)
        {
            if (hand == controlHand)
            {
                renderer.material = normalMat;
                controlHand = null;
                vehicle.acceleration = 0;
                vehicle.turnSpeed = 0;
            }
        }

        private void HandHoverUpdate(Hand hand)
        {
            if(hand == controlHand)
            {
                Vector3 offset = transform.InverseTransformPoint(hand.transform.position);
                offset.y = 0;
                vehicle.acceleration = (offset.z * forwardForce) + baseForwardSpeed;
                vehicle.turnSpeed = offset.x * rotationForce;
            }
        }


    }
}

