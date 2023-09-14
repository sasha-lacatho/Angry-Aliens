using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    public TriggerListener HitCollider;
    public override void Attack(Vector3 target, float charge)
    {
        HitCollider.OnTrigger = OnHit;
    }

    private void OnHit(Collider2D hit)
    {
        Debug.Log(hit.name);
    }

    public override void Preview(Vector3 target, float charge)
    {
        Vector2 direction = target - _character.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.localPosition = direction.normalized;
    }
}
