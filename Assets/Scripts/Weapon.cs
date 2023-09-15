using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TextCore.Text;

public abstract class Weapon : MonoBehaviour
{
    public int Damage;
    public int KnockBack;

    protected Vector3 _target;
    [HideInInspector]
    public float Charge;

    [Header("Events")]
    public UnityEvent OnStartCharge;
    public UnityEvent OnAttack;


    public abstract void Preview(Vector3 target, float charge);
    public virtual void Attack(Vector3 target, float charge)
    {
        _target = target;
        Charge = charge;

        OnAttack.Invoke();
    }
}
