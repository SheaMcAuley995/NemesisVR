using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSpellEffect : MonoBehaviour {

    public ParticleSystem[] spellEffects;



    private void Awake()
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
                ps.Clear();
            }
            else
            {
                ps.Play();
            }
        }
    }

}
