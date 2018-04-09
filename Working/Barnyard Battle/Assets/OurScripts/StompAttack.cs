using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompAttack : PWCowPawn{

    public float damageAmount = 10.0f;
    
    public void OnCollsionEnter(Collision other)
    {
        Actor OtherActor = other.gameObject.GetComponentInParent<Actor>();
        if (OtherActor)
        {
            OtherActor.TakeDamage(this, damageAmount, new DamageEventInfo(typeof(ProjectileDamageType)), Owner);
        }
        GetComponent<CapsuleCollider>().enabled = false;
    }

    public void NoCollision()
    {
        GetComponent<CapsuleCollider>().enabled = false;
    }
}
