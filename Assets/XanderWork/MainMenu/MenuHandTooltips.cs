using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Valve.VR.InteractionSystem
{
    public class MenuHandTooltips : MonoBehaviour
    {

        [Header("Tooltips")]
        public GameObject selectSpeed;
        public GameObject selectRelease;
        public GameObject teamSunStart;
        public GameObject teamMoonStart;

        [Header("Links")]
        public Hand hand;
        public SpellBox speedBoost;
        public SpellBox releaseBall;
        public GameStartObj sun;
        public GameStartObj moon;



        private void Update()
        {
            SetTooltip();
        }

        private void SetTooltip()
        {
            selectSpeed.SetActive(false);
            selectRelease.SetActive(false);
            teamMoonStart.SetActive(false);
            teamSunStart.SetActive(false);

            if(speedBoost.IsHandIn(hand))
            {
                selectSpeed.SetActive(true);
            }
            else if (releaseBall.IsHandIn(hand))
            {
                selectRelease.SetActive(true);
            }
            else if (sun.IsHandIn(hand))
            {
                teamSunStart.SetActive(true);
            }
            else if (moon.IsHandIn(hand))
            {
                teamMoonStart.SetActive(true);
            }
        }
    }
}
