using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseBallSpell : SpellAbstract {

    public float lifetime = 10.0f;
    public float releaseShootForce = 10000.0f;
    public float randomDirectionMult;
    public float pushLength = 1.0f;
    public float pushForce = 100.0f;

    public Renderer rend;

    private Rigidbody target = null;



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
        if(other.tag == enemyTeamTag && target == null)
        {
            GrabBall gb = other.transform.GetComponentInChildren<GrabBall>();
            if(gb.holdingBall)
            {
                other.transform.GetComponentInChildren<GrabBall>().ShootBall(releaseShootForce, Vector3.up + Random.onUnitSphere * randomDirectionMult);
                target = other.GetComponent<Rigidbody>();
                rend.enabled = false;
                CancelInvoke();
                Invoke("Remove", pushLength);
            }
        }
    }

    private void Update()
    {
        if (target != null)
        {
            target.AddForce(-transform.up * pushForce);
        }
    }

}
