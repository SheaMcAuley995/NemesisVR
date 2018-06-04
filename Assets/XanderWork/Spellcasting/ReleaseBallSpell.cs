using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseBallSpell : SpellAbstract {

    private float lifetime = 10.0f;
    private float releaseShootForce = 10000.0f;

    public override void Shoot()
    {
        Invoke("Remove", lifetime);
    }

    public void Remove()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == enemyTeamTag)
        {
            other.transform.GetComponentInChildren<GrabBall>().ShootBall(releaseShootForce);
            Remove();
        }
    }

}
