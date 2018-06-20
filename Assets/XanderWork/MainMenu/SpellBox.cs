﻿using System.Collections;
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
        public ParticleSystem selectEffect;
        public MenuSpellEffect menuSpellEffect;

        private int handsIn = 0;



        private void Start()
        {
            renderer.material = normalMat;

            //Both spell boxes will do this, making the starting spell effectively random.
            //SetSpell();
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
                SetSpell();
            }
        }

        private void SetSpell()
        {
            SceneBridge.Instance.spellPrefab = spellPrefab;
            SceneBridge.Instance.staffSpellEffectPrefab = staffSpellEffectPrefab;
            menuSpellEffect.SetSpell(selectEffect);
        }

    }
}
