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
                    spell.GetComponent<Rigidbody>().AddForce(spellEffectObj.forward * spellShootForce);
                    spellPrefab = null;
                    Destroy(spellEffectObj.gameObject);
                    spellEffectObj = null;
                }
                spellShootDebounce = false;
            }
        }

    }
}
