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
        public AudioSource audioSource;
        public ParticleSystem speedBoostField;
        public ParticleSystem releaseBallField;
        public ParticleSystem shootBallField;

        [Header("PROTOTYPING")]
        public Renderer renderer;
        public Material normalMat;
        public Material touchingMat;
        public Material cooldownMat;
        
        private List<Hand> handsIn = new List<Hand>();
        private List<SpellCaster> handHeads = new List<SpellCaster>();
        private float spellHeat = 0;
        private float spellCooldownTime;
        private ParticleSystem magicField = null;

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
                if(spellPrefab.GetComponent<ReleaseBallSpell>())
                {
                    magicField = releaseBallField;
                    magicField.gameObject.SetActive(true);
                }
                else if(spellPrefab.GetComponent<SpeedBostSpell>())
                {
                    magicField = speedBoostField;
                    magicField.gameObject.SetActive(true);
                }
            }
            if(SceneBridge.Instance.staffSpellEffectPrefab != null)
            {
                staffSpellEffectPrefab = SceneBridge.Instance.staffSpellEffectPrefab;
            }

            spellCooldownTime = spellPrefab.GetComponent<SpellAbstract>().cooldownTime;
        }

        private void OnHandHoverBegin(Hand hand)
        {
            handsIn.Add(hand);
            handHeads.Add(hand.transform.GetComponentInChildren<SpellCaster>());
            if (!grabBallScript.holdingBall && spellHeat <= 0)
            {
                renderer.material = touchingMat;
            }
        }
        private void OnHandHoverEnd(Hand hand)
        {
            handsIn.Remove(hand);
            handHeads.Remove(hand.transform.GetComponentInChildren<SpellCaster>());
            if (handsIn.Count == 0 && !grabBallScript.holdingBall && spellHeat <= 0)
            {
                renderer.material = normalMat;
                magicField.gameObject.SetActive(true);
                shootBallField.gameObject.SetActive(false);
            }
        }

        public void OnGrabBall()
        {
            //handsIn.Clear();
            //handHeads.Clear();
            renderer.material = cooldownMat;
            magicField.gameObject.SetActive(false);
            shootBallField.gameObject.SetActive(true);
        }

        public void OnReleaseBall()
        {
            if (handsIn.Count == 0)
            {
                renderer.material = normalMat;
            }
            else
            {
                renderer.material = touchingMat;
            }
            magicField.gameObject.SetActive(true);
            shootBallField.gameObject.SetActive(false);
        }

        private void Update()
        {
            if(spellHeat > 0)
            {
                spellHeat -= Time.deltaTime;
                if(spellHeat <= 0 && !grabBallScript.holdingBall)
                {
                    if(handsIn.Count == 0)
                    {
                        renderer.material = normalMat;
                    }
                    else
                    {
                        renderer.material = touchingMat;
                    }
                    magicField.gameObject.SetActive(true);
                    shootBallField.gameObject.SetActive(false);
                }
            }

            for(int i = 0; i < handsIn.Count; ++i)
            {
                Hand hand = handsIn[i];
                if(!grabBallScript.holdingBall && hand.GetStandardInteractionButtonDown()
                 && handHeads[i].spellEffectObj == null && spellHeat <= 0)
                {
                    audioSource.PlayOneShot(audioSource.clip);
                    GameObject spellEffect = Instantiate(staffSpellEffectPrefab);
                    spellEffect.transform.position = handHeads[i].transform.position;
                    spellEffect.transform.rotation = handHeads[i].transform.rotation;
                    handHeads[i].spellEffectObj = spellEffect.transform;
                    handHeads[i].spellPrefab = spellPrefab;
                    handHeads[i].spellShootDebounce = true;
                }
                else if(grabBallScript.holdingBall && hand.GetStandardInteractionButtonDown()
                    && SpellCaster.aimer == null)
                {
                    SpellCaster.aimer = hand.GetComponentInChildren<SpellCaster>();
                }
            }
        }

        public bool IsHandIn(Hand hand)
        {
            return handsIn.Contains(hand);
        }

        public bool IsInCooldown()
        {
            return spellHeat > 0;
        }

        public void OnSpellCast()
        {
            //handsIn.Clear();
            //handHeads.Clear();
            renderer.material = cooldownMat;
            magicField.gameObject.SetActive(false);
            spellHeat = spellCooldownTime;
        }

    }
}
