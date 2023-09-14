using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField]
    protected int _maxHealth;
    [SerializeField]
    protected int _health;
    [SerializeField]
    private int _minimumImpact = 5;
    [SerializeField]
    private float _impactDamageReceived = 1;

    public void TakeDamage(int damage)
    {
        if(damage > 0)
        {
            Debug.Log($"Take {damage} Damages");
            _health -= damage;
            OnTakeDamage();
            if (_health < 0)
            {
                OnDeath();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D selfRB = collision.otherRigidbody;
        Rigidbody2D otherRB = collision.rigidbody;

        Vector3 selfForce = selfRB.velocity;
        Vector3 otherForce = Vector3.zero;
        if(otherRB)
        {
            otherForce = otherRB.velocity * otherRB.mass / selfRB.mass;
        }

        float impact = (otherForce - selfForce).magnitude;
        if(impact > _minimumImpact)
        {
            //Debug.Log($"{this.name} > {collision.collider.gameObject.name} : S.{selfForce} O.{otherForce} : I.{impact}");
            TakeDamage(Mathf.RoundToInt(impact * _impactDamageReceived));
        }
    }

    public abstract void OnTakeDamage();
    public abstract void OnDeath();
}
