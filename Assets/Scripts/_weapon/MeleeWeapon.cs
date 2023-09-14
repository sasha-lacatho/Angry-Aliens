using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    public TriggerListener HitCollider;
    public int AttackFrames;
    private int _attackFrames;
    public override void Attack(Vector3 target, float charge)
    {
        base.Attack(target, charge);

        HitCollider.OnTrigger = OnHit; 
        HitCollider.Collider.enabled = true;
        _attackFrames = AttackFrames;
    }

    private void FixedUpdate()
    {
        if(_attackFrames > 0)
        {
            _attackFrames--;

            if (_attackFrames == 0) { HitCollider.Collider.enabled = false; }
        }
    }

    private void OnHit(Collider2D hit)
    {
        Debug.Log(hit.name);

        if(hit.TryGetComponent(out Entity entity) && entity != _character)
        {
            entity.TakeDamage(_damage);
            entity.KnockBack((_target - _character.transform.position).normalized * _knockBack * _charge);
        }
    }

    public override void Preview(Vector3 target, float charge)
    {
        Vector2 direction = target - _character.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.localPosition = direction.normalized;
    }
}
