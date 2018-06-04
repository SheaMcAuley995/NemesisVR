using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Valve.VR.InteractionSystem
{

    [RequireComponent(typeof(Interactable))]
    public class SpellBox : MonoBehaviour
    {

        public GameObject spellPrefab;
        public GameObject staffSpellEffectPrefab;

        public Renderer renderer;
        public Material normalMat;
        public Material touchingMat;
        public Material holdingMat;

        private int handsIn = 0;



        private void Start()
        {
            renderer.material = normalMat;
        }

        private void OnHandHoverBegin(Hand hand)
        {
            renderer.material = touchingMat;
            ++handsIn;
        }

        private void OnHandHoverEnd(Hand hand)
        {
            --handsIn;
            if (handsIn == 0)
            {
                renderer.material = normalMat;
            }
        }

        private void HandHoverUpdate(Hand hand)
        {
            if (hand.GetStandardInteractionButtonDown())
            {
                renderer.material = holdingMat;
                SceneBridge.Instance.spellPrefab = spellPrefab;
                SceneBridge.Instance.staffSpellEffectPrefab = staffSpellEffectPrefab;
            }
        }

    }
}
