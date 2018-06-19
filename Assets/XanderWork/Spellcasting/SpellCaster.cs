using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class SpellCaster : MonoBehaviour {

        private static SpellCaster aimer = null;

        public float spellShootForce;
        public Hand hand;
        public GameObject spellPrefab = null;
        public Transform spellEffectObj = null;
        public bool spellShootDebounce = true;
        public GrabBall grabBallScript;
        public VehicleController vc;

        [Header("Aiming")]
        public Transform beetleHead;
        public float headPitchMult;
        public float headYawMult;
        public float headRollMult;

        private string enemyTeamTag;
        private string allyTeamTag;

        private Vector3 aimStartPos = Vector3.zero;



        private void Start()
        {
            if (SceneBridge.Instance.playerTeam == TeamManager.TeamBall.Sun)
            {
                enemyTeamTag = "TeamMoon";
                allyTeamTag = "TeamSun";
            }
            else
            {
                enemyTeamTag = "TeamSun";
                allyTeamTag = "TeamMoon";
            }

            grabBallScript.onGrabBall += OnGrabBall;
            grabBallScript.onReleaseBall += OnReleaseBall;
        }

        private void Update()
        {
            if (grabBallScript.holdingBall && hand.GetStandardInteractionButton()
                && aimer == null && ControlZone.Instance.controlHand != hand
                && ControlZone.Instance.controlHand != null)
            {
                vc.handleHeadRotation = false;
                aimStartPos = vc.transform.InverseTransformPoint(hand.transform.position);
                aimer = this;
            }

            if (aimer == this)
            {
                if (grabBallScript.holdingBall && hand.GetStandardInteractionButtonUp())
                {
                    vc.handleHeadRotation = true;
                    grabBallScript.ShootBall(ControlZone.Instance.ballShootForce);
                    aimer = null;
                }

                if (!vc.handleHeadRotation)
                {
                    Vector3 offset = vc.transform.InverseTransformPoint(hand.transform.position)
                                                                          - aimStartPos;
                    Vector3 newEuler = new Vector3(vc.headRotDefault.x + -offset.y * headPitchMult,
                                                   vc.headRotDefault.y + offset.x * headYawMult,
                                                   vc.headRotDefault.z + 0 * headRollMult);
                    
                    beetleHead.localEulerAngles = newEuler;
                }
            }
        }

        private void LateUpdate()
        {
            if(spellEffectObj != null)
            {
                spellEffectObj.position = transform.position;
                spellEffectObj.rotation = transform.rotation;
                if(hand.GetStandardInteractionButtonDown() && !spellShootDebounce)
                {
                    GameObject spell = Instantiate(spellPrefab);
                    spell.transform.position = transform.position;
                    spell.transform.rotation = transform.rotation;
                    SpellAbstract script = spell.GetComponent<SpellAbstract>();
                    script.enemyTeamTag = enemyTeamTag;
                    script.allyTeamTag = allyTeamTag;
                    script.Shoot();
                    spell.GetComponent<Rigidbody>().AddForce(-spellEffectObj.up * spellShootForce);
                    spellPrefab = null;
                    Destroy(spellEffectObj.gameObject);
                    spellEffectObj = null;

                    SpellZone.Instance.OnSpellCast();
                }
                spellShootDebounce = false;
            }
        }

        public void OnGrabBall()
        {
            if(spellEffectObj != null)
            {
                Destroy(spellEffectObj.gameObject);
                spellEffectObj = null;
            }
        }

        public void OnReleaseBall()
        {
            vc.handleHeadRotation = true;
            aimer = null;
        }

    }
}
