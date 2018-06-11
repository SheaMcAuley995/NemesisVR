using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Valve.VR.InteractionSystem
{
    [RequireComponent(typeof(Interactable))]
    public class ControlZone : MonoBehaviour
    {

        public VehicleController vehicle;
        public float baseForwardAccel;
        public float forwardForce;
        public float rotationForce;

        public Transform controlPoint;
        public float controlPointSpeed;

        public GrabBall grabScript;
        public float ballShootForce;

        public Hand[] hands;

        public SpellZone spellZone;

        [Header("PROTOTYPING")]
        public Renderer renderer;
        public Material normalMat;
        public Material touchingMat;

        private Hand controlHand = null;

        private Vector3 controlPointTarget;



        private void Start()
        {
            renderer.material = normalMat;
            renderer.enabled = false;

            vehicle.acceleration = baseForwardAccel;
            vehicle.turnSpeed = 0;
        }

        private void Update()
        {
            foreach(Hand h in hands)
            {
                if (h.GetStandardInteractionButtonDown() && controlHand == null
                && !spellZone.IsHandIn(h)
                && h.transform.Find("Scepter").Find("HeadPos").GetComponent<SpellCaster>().spellEffectObj == null)
                {
                    controlHand = h;
                    transform.position = h.transform.position;
                    controlPoint.position = transform.position;
                    renderer.enabled = true;
                }
                else if(!h.GetStandardInteractionButton() && controlHand == h)
                {
                    controlHand = null;
                    renderer.enabled = false;
                    vehicle.acceleration = baseForwardAccel;
                    vehicle.turnSpeed = 0;
                }
            }

            if(controlHand == null)
            {
                controlPointTarget = transform.position;
            }
            else
            {
                controlPointTarget = transform.InverseTransformPoint(controlHand.transform.position);

                if (controlPointTarget.x > transform.localScale.x)
                {
                    controlPointTarget.x = transform.localScale.x;
                }
                else if (controlPointTarget.x < -transform.localScale.x)
                {
                    controlPointTarget.x = -transform.localScale.x;
                }

                if (controlPointTarget.y > transform.localScale.y)
                {
                    controlPointTarget.y = transform.localScale.y;
                }
                else if (controlPointTarget.y < -transform.localScale.y)
                {
                    controlPointTarget.y = -transform.localScale.y;
                }

                if (controlPointTarget.z > transform.localScale.z)
                {
                    controlPointTarget.z = transform.localScale.z;
                }
                else if (controlPointTarget.z < -transform.localScale.z)
                {
                    controlPointTarget.z = -transform.localScale.z;
                }

                controlPointTarget = transform.TransformPoint(controlPointTarget);

                Vector3 offset = transform.InverseTransformPoint(controlPoint.transform.position);
                vehicle.acceleration = (offset.z * forwardForce) + baseForwardAccel;
                vehicle.turnSpeed = offset.x * rotationForce;
            }

            if (Vector3.Distance(controlPoint.position, controlPointTarget) > controlPointSpeed * Time.deltaTime)
            {
                controlPoint.position += (controlPointTarget - controlPoint.position).normalized * controlPointSpeed * Time.deltaTime;
            }
        }

        //private void OnHandHoverBegin(Hand hand)
        //{
        //    if (controlHand == null)
        //    {
        //        renderer.material = touchingMat;
        //        controlHand = hand;
        //    }
        //}
        //
        //private void OnHandHoverEnd(Hand hand)
        //{
        //    if (hand == controlHand)
        //    {
        //        renderer.material = normalMat;
        //        controlHand = null;
        //        vehicle.acceleration = baseForwardAccel;
        //        vehicle.turnSpeed = 0;
        //    }
        //}
        //
        //private void HandHoverUpdate(Hand hand)
        //{
        //    if(hand == controlHand)
        //    {
        //        controlPointTarget = hand.transform.position;
        //
        //        Vector3 offset = transform.InverseTransformPoint(controlPoint.transform.position);
        //        vehicle.acceleration = (offset.z * forwardForce) + baseForwardAccel;
        //        vehicle.turnSpeed = offset.x * rotationForce;
        //
        //        if(hand.GetStandardInteractionButtonDown())
        //        {
        //            grabScript.ShootBall(ballShootForce);
        //        }
        //    }
        //}

    }
}

