using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : Entity
{
    public override void OnDeath()
    {
        Destroy(gameObject);
        Debug.Log("Structure destroyed");
    }

    public override void OnTakeDamage()
    {
    }
}
