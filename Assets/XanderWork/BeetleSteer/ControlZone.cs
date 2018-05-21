using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Valve.VR.InteractionSystem
{
    [RequireComponent(typeof(Interactable))]
    public class ControlZone : MonoBehaviour
    {

        public VehicleController vehicle;
        public float forwardForce;

        [Header("PROTPTYPING")]
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
            renderer.material = normalMat;
            if (hand == controlHand)
            {
                controlHand = null;
            }
        }

        private void HandHoverUpdate(Hand hand)
        {
            Vector3 offset = hand.transform.position - transform.position;
            vehicle.acceleration = offset.z * forwardForce;
        }


    }
}

