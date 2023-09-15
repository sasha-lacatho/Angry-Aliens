using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootWeapon : Weapon
{
    public LineRenderer LineRenderer;
    public override void Attack(Vector3 target, float charge)
    {
        base.Attack(target, charge);

        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, (target - transform.position).normalized, float.PositiveInfinity, LayerUtility.TerrainMask + LayerUtility.CharacterMask);

        foreach (RaycastHit2D hit in hits)
        {
            if(hit.collider.TryGetComponent(out Entity entity) && entity != Character.Current)
            {
                OnHit(entity);
                break;
            }
        }
    }


    private void OnHit(Entity entity)
    {
        entity.TakeDamage(Damage);
        entity.KnockBack((_target - Character.Current.transform.position).normalized * KnockBack * Charge);
    }

    public override void Preview(Vector3 target, float charge)
    {
        Vector2 direction = target - Character.Current.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.localPosition = direction.normalized;

        LineRenderer.SetPositions(new Vector3[] { Character.Current.transform.position, (direction.normalized * KnockBack * charge) + (Vector2)Character.Current?.transform.position });
    }
}
