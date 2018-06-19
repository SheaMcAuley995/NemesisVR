using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Valve.VR.InteractionSystem
{
    [RequireComponent(typeof(Interactable))]
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
        private float spellHeat = 0;
        private float spellCooldownTime;

        public static SpellZone Instance { get; private set; }




        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            renderer.material = normalMat;

            grabBallScript.onGrabBall += OnGrabBall;
            grabBallScript.onReleaseBall += OnReleaseBall;

            if (SceneBridge.Instance.spellPrefab != null)
            {
                spellPrefab = SceneBridge.Instance.spellPrefab;
            }
            if(SceneBridge.Instance.staffSpellEffectPrefab != null)
            {
                staffSpellEffectPrefab = SceneBridge.Instance.staffSpellEffectPrefab;
            }

            spellCooldownTime = spellPrefab.GetComponent<SpellAbstract>().cooldownTime;
        }

        private void OnHandHoverBegin(Hand hand)
        {
            if (!grabBallScript.holdingBall && spellHeat <= 0)
            {
                renderer.material = touchingMat;
                handsIn.Add(hand);
                handHeads.Add(hand.transform.GetComponentInChildren<SpellCaster>());
            }
        }
        private void OnHandHoverEnd(Hand hand)
        {
            if (!grabBallScript.holdingBall && spellHeat <= 0)
            {
                handsIn.Remove(hand);
                handHeads.Remove(hand.transform.GetComponentInChildren<SpellCaster>());
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
            if(spellHeat > 0)
            {
                spellHeat -= Time.deltaTime;
                if(spellHeat <= 0 && !grabBallScript.holdingBall)
                {
                    renderer.material = normalMat;
                }
            }

            for(int i = 0; i < handsIn.Count; ++i)
            {
                Hand hand = handsIn[i];
                if(hand.GetStandardInteractionButtonDown() && handHeads[i].spellEffectObj == null && spellHeat <= 0)
                {
                    GameObject spellEffect = Instantiate(staffSpellEffectPrefab);
                    spellEffect.transform.position = handHeads[i].transform.position;
                    spellEffect.transform.rotation = handHeads[i].transform.rotation;
                    handHeads[i].spellEffectObj = spellEffect.transform;
                    handHeads[i].spellPrefab = spellPrefab;
                    handHeads[i].spellShootDebounce = true;
                }
            }
        }

        public bool IsHandIn(Hand hand)
        {
            return handsIn.Contains(hand);
        }

        public void OnSpellCast()
        {
            handsIn.Clear();
            handHeads.Clear();
            renderer.material = cooldownMat;
            spellHeat = spellCooldownTime;
        }

    }
}
