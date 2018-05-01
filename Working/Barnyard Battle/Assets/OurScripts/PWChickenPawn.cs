using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PWChickenPawn : PWPawn
{
    Rigidbody rb;
    public float MoveSpeed = 15f;
    public float RotateSpeed = 180f;
    public float MinVelocity = .01f;
    float damageAmount = 5.0f;

    //public Transform ProjectileSpawn;
    //public GameObject Projectile1;
    //public GameObject Projectile2;
    //GameObject currentProjectile;
    
    PWPlayerController PWC;

    public virtual void Start()
    {
        IsSpectator = false;

        // Add and Set up Rigid Body
        rb = gameObject.AddComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;


        Health = StartingHealth;

        //Life = StartingLife;
        //currentProjectile = Projectile1;

        PWC = (PWPlayerController)controller;
        Life = PWC.Live();
    }

    protected override bool ProcessDamage(Actor Source, float Value, DamageEventInfo EventInfo, Controller Instigator)
    {
        Health -= Value;
        LOG(ActorName + " HP: " + Health);

        if (Health <= 0)
        {
            controller.RequestSpectate();
            Destroy(gameObject);
            PWC.Deaths();
        }
        
       // if(deaths > 3)
        //{
            //add code here
       // }

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
            
            // Fire Projectile
            //Factory(currentProjectile, ProjectileSpawn.position, ProjectileSpawn.rotation, controller);
        }
    }

    public override void Fire2(bool value)
    {
        if (value)
        {
            // Set Current Projectile to Prijectile 1
            //currentProjectile = Projectile1;
        }
    }

    public override void Fire3(bool value)
    {
        if (value)
        {
            // Set Current Projectile to Prijectile 2
            //currentProjectile = Projectile2;
        }
    }

    void OnCollisionEnter (Collision other)
    {
        Actor OtherActor = other.gameObject.GetComponentInParent<Actor>();
        if (OtherActor)
        {
            OtherActor.TakeDamage(this, damageAmount, new DamageEventInfo(typeof(ProjectileDamageType)), Owner);
        }
    }
}
