using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Entity
{
    private CharacterMovement _currentController;
    [SerializeField]
    private CharacterMovement _defaultController;


    public CharacterMovement GetController()
    {
        return _currentController ? _currentController : _defaultController;
    }

    public override void OnDeath()
    {
        Destroy(gameObject);
        Debug.Log("OnDeath");
    }
}
