using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Valve.VR.InteractionSystem
{
    public class SpellZone : MonoBehaviour
    {

        public GameObject spellPrefab;
        public GameObject staffSpellEffectPrefab;

        [Header("PROTOTYPING")]
        public Renderer renderer;
        public Material normalMat;
        public Material touchingMat;

        private int touchingHandCount = 0;
        private List<Hand> handsIn = new List<Hand>();
        private List<SpellCaster> handHeads = new List<SpellCaster>();


        private void Start()
        {
            renderer.material = normalMat;
        }

        private void OnTriggerEnter(Collider other)
        {
            renderer.material = touchingMat;
            handsIn.Add(other.transform.parent.parent.GetComponent<Hand>());
            handHeads.Add(other.transform.GetComponent<SpellCaster>());
        }

        private void OnTriggerExit(Collider other)
        {
            handsIn.Remove(other.transform.parent.parent.GetComponent<Hand>());
            handHeads.Remove(other.transform.GetComponent<SpellCaster>());
            if (handsIn.Count == 0)
            {
                renderer.material = normalMat;
            }
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

    }
}
