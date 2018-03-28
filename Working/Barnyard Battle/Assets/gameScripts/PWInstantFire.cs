using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PWInstantFire : PWPawn
{
    public Transform barrel;
    Rigidbody rb;
    public float MoveSpeed = 10f;
    public float RotateSpeed = 180f;
    public float MinVelocity = .01f;
    public float damageAmount = 10f;
    LineRenderer Laser;
    int LaserCounter = 0;
    public int LaserTime = 5;
    public virtual void Start()
    {
        Laser = gameObject.GetComponent<LineRenderer>();
        Laser.enabled = false;
        if (!Laser)
        {
            LOG_ERROR("NO PEW PEW");
        }
        //Screen.lockCursor = true;


        IsSpectator = false;

        // Add and Set up Rigid Body
        rb = gameObject.AddComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;


        Energy = StartingEnergy;
        Shields = StartingShields;

    }

    protected override bool ProcessDamage(Actor Source, float Value, DamageEventInfo EventInfo, Controller Instigator)
    {
        Shields -= Value;
        Lives += 1;
        LOG(ActorName + " HP: " + Shields);

        if (Shields <= 0)
        {
            controller.RequestSpectate();
            
            //Destroy(gameObject);

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

        if (Laser.enabled)
        {
            Ray ray = new Ray(barrel.position, barrel.forward);
            Laser.SetPosition(0, ray.origin);
            Laser.SetPosition(1, ray.GetPoint(100));
            LaserCounter++;
            if (LaserCounter >= LaserTime)
            {
                Laser.enabled = false;

            }
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
            //LOG("FIRE!"); 
            Laser.enabled = true;
            LaserCounter = 0;

            RaycastHit hitinfo;
            Debug.Log("raycast out");
            if (Physics.Raycast(barrel.position, barrel.forward, out hitinfo, 100))
            {
                Debug.Log("Raycast Hit " + hitinfo.collider.name);
                Collider other = hitinfo.collider;
                Actor OtherActor = other.gameObject.GetComponentInParent<Actor>();
                if (OtherActor)
                {
                    OtherActor.TakeDamage(this, damageAmount, new DamageEventInfo(typeof(InstantFireDamageType)), Owner);
                }
            }
        }

    }
}


