using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    public int Health;

    private int _maxHealth;

    private CharacterMovement _currentController;
    [SerializeField]
    private CharacterMovement _defaultController;


    public CharacterMovement GetController()
    {
        return _currentController ? _currentController : _defaultController;
    }
}
