using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeWeapon : Weapon
{
    public LineRenderer LineRenderer;
    public GrenadeMunition Munition;
    public float ThrowForce;

    public override void Attack(Vector3 target, float charge)
    {
        base.Attack(target, charge);

        GrenadeMunition grenade = GameObject.Instantiate(Munition.gameObject).GetComponent<GrenadeMunition>();

        grenade.transform.position = transform.position;
        grenade.Launch((target - transform.position).normalized * charge * ThrowForce, this);
    }

    public override void Preview(Vector3 target, float charge)
    {
        Vector2 direction = (target - Character.Current.transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.position = Character.Current.transform.position + (Vector3)direction.normalized;

        Vector3 start = transform.position;
        Vector3 velocity = ThrowForce * charge * direction;
        for(int i = 0; i < LineRenderer.positionCount; i++)
        {
            float t = (float)i * 0.1f;

            Vector3 position = start + t * velocity;
            position.y += Physics2D.gravity.y / 2f * t * t;

            LineRenderer.SetPosition(i, position);
            
            //Debug.Log(position);
        }

    }
}
