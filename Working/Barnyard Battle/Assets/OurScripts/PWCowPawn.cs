using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PWCowPawn : PWPawn{
    Rigidbody rb;
    public float MoveSpeed = 5f;
    public float RotateSpeed = 180f;
    public float MinVelocity = .01f;

    public Collider cow;
    public float damageAmount = 10.0f;

    PWPlayerController PWC;

    public virtual void Start()
    {
        IsSpectator = false;

        // Add and Set up Rigid Body
        rb = gameObject.AddComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        Energy = StartingEnergy;
        Shields = StartingShields;

        // SA = gameObject.AddComponent<StompAttack>(); 
        PWC = (PWPlayerController)controller;
    }

    protected override bool ProcessDamage(Actor Source, float Value, DamageEventInfo EventInfo, Controller Instigator)
    {
        Shields -= Value;
        LOG(ActorName + " HP: " + Shields);

        if (Shields <= 0)
        {
            controller.RequestSpectate();
            Destroy(gameObject);
            PWC.Deaths();
        } 

        return base.ProcessDamage(Source, Value, EventInfo, Instigator);

    }

    public override void OnUnPossession()
    {
        IgnoresDamage = true;
    }

    public virtual void FixedUpdate()
    {
        if (rb.velocity.magnitude < MinVelocity)
        {
            rb.velocity = Vector3.zero;
        }
    }

    public override void Horizontal(float value)
    {
        if (value != 0)
        {
            //LOG("Pawn-Horizontal (" + value + ")");
            gameObject.transform.Rotate(0, (RotateSpeed * value * Time.fixedDeltaTime), 0);
        }
    }

    public override void Vertical(float value)
    {
        if (value != 0)
        {
            rb.velocity = gameObject.transform.forward * MoveSpeed * value;
        }
    }

    public override void Fire1(bool value)
    {
        if (value)
        {
            // SA.Stomp(transform.position, 300, cow);
            Stomp(this.Location, 300, cow);
        }
    }

    public override void Fire2(bool value)
    {
        if (value)
        {
        }
    }

    public override void Fire3(bool value)
    {
        if (value)
        {
            
        }
    }

    public void Stomp(Vector3 center, float radius, Collider cow)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        foreach (Collider c in hitColliders)
        {
            Debug.Log("Hit : " + c.gameObject.name);
            
            Actor OtherActor = c.gameObject.GetComponentInParent<Actor>();
            if (c != cow)
            {
                if (OtherActor)
                {
                    Debug.Log("Actor-TakeDamage : " + OtherActor.name);
                    OtherActor.TakeDamage(this, damageAmount, new DamageEventInfo(typeof(ProjectileDamageType)), Owner);
                }
            }
            
        }

    }

}
