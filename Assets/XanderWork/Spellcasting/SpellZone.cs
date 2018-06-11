using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Valve.VR.InteractionSystem
{
    public class SpellZone : MonoBehaviour
    {

        public GameObject spellPrefab;
        public GameObject staffSpellEffectPrefab;
        public GrabBall grabBallScript;

        [Header("PROTOTYPING")]
        public Renderer renderer;
        public Material normalMat;
        public Material touchingMat;
        public Material cooldownMat;
        
        private List<Hand> handsIn = new List<Hand>();
        private List<SpellCaster> handHeads = new List<SpellCaster>();


        private void Start()
        {
            renderer.material = normalMat;

            grabBallScript.onGrabBall += OnGrabBall;
            grabBallScript.onReleaseBall += OnReleaseBall;

            if(SceneBridge.Instance.spellPrefab != null)
            {
                spellPrefab = SceneBridge.Instance.spellPrefab;
            }
            if(SceneBridge.Instance.staffSpellEffectPrefab != null)
            {
                staffSpellEffectPrefab = SceneBridge.Instance.staffSpellEffectPrefab;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(!grabBallScript.holdingBall)
            {
                renderer.material = touchingMat;
                handsIn.Add(other.transform.parent.parent.GetComponent<Hand>());
                handHeads.Add(other.transform.GetComponent<SpellCaster>());
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if(!grabBallScript.holdingBall)
            {
                handsIn.Remove(other.transform.parent.parent.GetComponent<Hand>());
                handHeads.Remove(other.transform.GetComponent<SpellCaster>());
                if (handsIn.Count == 0)
                {
                    renderer.material = normalMat;
                }
            }
        }

        public void OnGrabBall()
        {
            handsIn.Clear();
            handHeads.Clear();
            renderer.material = cooldownMat;
        }

        public void OnReleaseBall()
        {
            renderer.material = normalMat;
        }

        private void Update()
        {
            for(int i = 0; i < handsIn.Count; ++i)
            {
                Hand hand = handsIn[i];
                if(hand.GetStandardInteractionButtonDown() && handHeads[i].spellEffectObj == null)
                {
                    GameObject spellEffect = Instantiate(staffSpellEffectPrefab);
                    spellEffect.transform.position = handHeads[i].transform.position;
                    spellEffect.transform.rotation = handHeads[i].transform.rotation;
                    handHeads[i].spellEffectObj = spellEffect.transform;
                    handHeads[i].spellPrefab = spellPrefab;
                    handHeads[i].spellShootDebounce = true;
                    //handsIn.RemoveAt(i);
                    //handHeads.RemoveAt(i);
                    //--i;
                }
            }
        }

        public bool IsHandIn(Hand hand)
        {
            return handsIn.Contains(hand);
        }

    }
}
