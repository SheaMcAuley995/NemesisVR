using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Valve.VR.InteractionSystem
{

    [RequireComponent(typeof(Interactable))]
    public class JoystickHandle : MonoBehaviour
    {

        public Renderer renderer;
        public Material normalMat;
        public Material touchingMat;
        public Material holdingMat;

        public delegate void JoystickControlUpdate(Hand hand);
        public JoystickControlUpdate joystickControlUpdate;

        private Hand controlHand = null;

        

        private void Start()
        {
            renderer.material = normalMat;
        }

        private void OnHandHoverBegin(Hand hand)
        {
            if(controlHand == null)
            {
                renderer.material = touchingMat;
            }
        }

        private void OnHandHoverEnd(Hand hand)
        {
            renderer.material = normalMat;
            if(hand == controlHand)
            {
                controlHand = null;
            }
        }

        private void HandHoverUpdate(Hand hand)
        {
            if (controlHand != null && hand.GetStandardInteractionButtonUp())
            {
                controlHand = null;
                renderer.material = touchingMat;
            }

            if (controlHand == null && hand.GetStandardInteractionButtonDown())
            {
                controlHand = hand;
                renderer.material = holdingMat;
            }

            if (hand == controlHand && joystickControlUpdate != null)
            {
                joystickControlUpdate(controlHand);
            }
        }

    }

}
