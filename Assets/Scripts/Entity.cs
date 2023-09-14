using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField]
    private int _maxHealth;
    [SerializeField]
    private int _health;
    [SerializeField]
    private int _resistance;

    public void TakeDamage(int damage)
    {
        damage -= _resistance;
        if(damage > 0)
        {
            _health -= damage;
            if(_health < 0)
            {
                OnDeath();
            }
        }
    }

    public abstract void OnDeath();
}
