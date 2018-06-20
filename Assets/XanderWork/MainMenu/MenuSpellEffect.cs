using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSpellEffect : MonoBehaviour {

    public ParticleSystem[] spellEffects;



    private void Start()
    {
        foreach (ParticleSystem ps in spellEffects)
        {
            ps.Stop();
        }
    }

    public void SetSpell(ParticleSystem particle)
    {
        foreach(ParticleSystem ps in spellEffects)
        {
            if(ps != particle)
            {
                ps.Stop();
            }
            else
            {
                ps.Play();
            }
        }
    }

}
