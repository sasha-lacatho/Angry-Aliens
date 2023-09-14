using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : Entity
{
    [Range(0, 3)]
    public int Id;
    [Range(0, 1)]
    public int TeamId;

    public static Character Current;

    private CharacterMovement _currentController;
    [SerializeField]
    private CharacterMovement _defaultController;

    [SerializeField]
    private Transform _healthBar;

    [Header("GD - Events")]
    public UnityEvent OnBeginWalkEvent;
    public UnityEvent OnEndWalkEvent;
    public UnityEvent OnTakeDamageEvent;
    public UnityEvent OnDeathEvent;

    public CharacterMovement GetController()
    {
        return _currentController ? _currentController : _defaultController;
    }

    private void Awake()
    {
        Debug.LogWarning("Remove this when integrating turn system");
        Current = this;
    }


    public override void OnDeath()
    {
        Destroy(gameObject);
        Debug.Log("OnDeath");
        OnDeathEvent.Invoke();
    }

    public override void OnTakeDamage()
    {
        OnTakeDamageEvent.Invoke();
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        float percent = (float)_health / (float)_maxHealth;

        _healthBar.localScale = new Vector3(percent, 1, 1); 
    }
}
