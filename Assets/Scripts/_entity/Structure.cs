using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : Entity
{
    [Header("Gravity")]
    public bool IgnoreGravity = false;
    public bool GravityWhenHit = false;


    private void Awake()
    {
        if(TryGetComponent(out Rigidbody2D rb))
        {
            rb.bodyType = IgnoreGravity ? RigidbodyType2D.Kinematic : RigidbodyType2D.Dynamic;
        }
    }

    public override void OnDeath()
    {
        Destroy(gameObject);
        Debug.Log("Structure destroyed");
    }

    public override void OnTakeDamage()
    {
        if (TryGetComponent(out Rigidbody2D rb))
        {
            rb.bodyType = GravityWhenHit | !IgnoreGravity ? RigidbodyType2D.Dynamic : RigidbodyType2D.Kinematic;
        }
    }
}
