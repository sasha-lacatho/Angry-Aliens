using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeMunition : MonoBehaviour
{
    public Rigidbody2D RigidBody;
    public TriggerListener HitCollider;


    public float Timer;
    private bool _exploded;

    public int AttackFrames;
    private int _attackFrames;
    private Weapon _weapon;

    public void Launch(Vector3 force, Weapon weapon)
    {
        _weapon = weapon;

        RigidBody.velocity = force;
    }

    private void Update()
    {
        if (!_exploded)
        {
            Timer -= Time.deltaTime;
            Debug.Log(Timer);
            if (Timer < 0)
            {
                Explode();
            }
        }
    }

    private void FixedUpdate()
    {
        if (_attackFrames > 0)
        {
            _attackFrames--;
            Debug.Log(_attackFrames);

            if (_attackFrames == 0) { 
                Destroy(gameObject);
            }
        }
    }
    private void Explode()
    {
        Debug.Log("Explode");
        _exploded = true;

        HitCollider.OnTrigger = OnHit;
        HitCollider.Collider.enabled = true;
        _attackFrames = AttackFrames;
    }

    private void OnHit(Collider2D hit)
    {
        Debug.Log(hit.name);

        if (hit.TryGetComponent(out Entity entity))
        {
            entity.TakeDamage(_weapon.Damage);
            entity.KnockBack((entity.transform.position - transform.position).normalized * _weapon.KnockBack * _weapon.Charge);
        }
    }
}
