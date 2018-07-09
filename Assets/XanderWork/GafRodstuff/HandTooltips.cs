using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Valve.VR.InteractionSystem
{
    public class HandTooltips : MonoBehaviour
    {

        [Header("Tooltips")]
        public GameObject holdTrigger;
        public GameObject steering;
        public GameObject pullTrigger;
        public GameObject aimShoot;

        [Header("Links")]
        public Hand hand;
        public SpellCaster spellCaster;
        public GrabBall grabBall;

        

        private void Update()
        {
            SetTooltip();
        }

        private void SetTooltip()
        {
            holdTrigger.SetActive(false);
            steering.SetActive(false);
            pullTrigger.SetActive(false);
            aimShoot.SetActive(false);

            if (spellCaster.spellEffectObj != null)
            {
                pullTrigger.SetActive(true);
            }
            else if (ControlZone.Instance.controlHand == hand)
            {
                steering.SetActive(true);
            }
            else if (spellCaster.IsAiming)
            {
                aimShoot.SetActive(true);
            }
            else if (!grabBall.holdingBall && SpellZone.Instance.IsHandIn(hand) && !SpellZone.Instance.IsInCooldown())
            {
                pullTrigger.SetActive(true);
            }
            else if((ControlZone.Instance.controlHand != null && grabBall.holdingBall)
                 || ControlZone.Instance.controlHand == null)
            {
                holdTrigger.SetActive(true);
            }
        }

    }
}
