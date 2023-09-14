using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField]
    protected int _damage;
    [SerializeField]
    protected int _knockBack;

    protected Character _character;

    protected Vector3 _target;
    protected float _charge;

    [Header("Events")]
    public UnityEvent OnStartCharge;
    public UnityEvent OnAttack;

    public void AttachTo(Character character)
    {
        transform.SetParent(character.transform);
        transform.localPosition = Vector3.zero;
        _character = character;
    }
    public abstract void Preview(Vector3 target, float charge);
    public virtual void Attack(Vector3 target, float charge)
    {
        _target = target;
        _charge = charge;
    }
}
