using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected Character _character;
    public void AttachTo(Character character)
    {
        transform.SetParent(character.transform);
        transform.localPosition = Vector3.zero;
        _character = character;
    }
    public abstract void Preview(Vector3 target, float charge);
    public abstract void Attack(Vector3 target, float charge);
}
