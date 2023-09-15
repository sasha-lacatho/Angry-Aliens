using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootWeapon : Weapon
{
    public LineRenderer LineRenderer;
    public override void Attack(Vector3 target, float charge)
    {
        Debug.LogWarning("Pew Pew");
        base.Attack(target, charge);

        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, (target - transform.position).normalized, float.PositiveInfinity, LayerUtility.TerrainMask + LayerUtility.CharacterMask);

        foreach (RaycastHit2D hit in hits)
        {
            Debug.Log(hit.collider.name);
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

        LineRenderer.SetPositions(new Vector3[] { _character.transform.position, (direction.normalized * _knockBack * charge) + (Vector2)_character.transform.position });
    }
}
