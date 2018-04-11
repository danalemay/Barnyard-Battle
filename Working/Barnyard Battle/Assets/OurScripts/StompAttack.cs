using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompAttack : Actor{

    public float damageAmount = 10.0f;

    public void Stomp(Vector3 center, float radius, Collider cow)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        foreach (Collider c in hitColliders)
        {            
            Actor OtherActor = c.gameObject.GetComponentInParent<Actor>();

            if (OtherActor != cow)
            {
                OtherActor.TakeDamage(this, damageAmount, new DamageEventInfo(typeof(ProjectileDamageType)), Owner);
            }
            Debug.Log("Hit");
        }

        /*int i = 0;
        while (i < hitColliders.Length)
        {
            Actor OtherActor = hitColliders[i].gameObject.GetComponentInParent<Actor>();
            
            if (OtherActor != cow)
            {
                    OtherActor.TakeDamage(this, damageAmount, new DamageEventInfo(typeof(ProjectileDamageType)), Owner);                
            }
            Debug.Log("Hit");
            i++;
        }*/
    }

    /*public void OnCollsionEnter(Collision other)
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
    }*/
}
