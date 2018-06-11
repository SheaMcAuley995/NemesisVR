using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class SpellCaster : MonoBehaviour {

        public float spellShootForce;
        public Hand hand;
        public GameObject spellPrefab = null;
        public Transform spellEffectObj = null;
        public bool spellShootDebounce = true;
        public GrabBall grabBallScript;

        private string enemyTeamTag;
        private string allyTeamTag;



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
                    spell.GetComponent<Rigidbody>().AddForce(spellEffectObj.forward * spellShootForce);
                    spellPrefab = null;
                    Destroy(spellEffectObj.gameObject);
                    spellEffectObj = null;
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

    }
}
