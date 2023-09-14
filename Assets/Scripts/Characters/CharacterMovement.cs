using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private float _moveForce;
    [SerializeField]
    private float _moveAccelleration;
    [SerializeField]
    private float _jumpForce;
    [SerializeField]
    private float _jumpVelocity;
    [SerializeField]
    private float _climbVelocity;


    private Rigidbody2D _rb;
    private Collider2D _collider;


    private Vector2 _direction;
    private bool _jumpKey;
    private bool _grounded;
    private bool _canClimb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
    }


    public void OnMove(Vector2 direction, bool jumpKey)
    {

        _direction = direction;
        _jumpKey = _jumpKey | jumpKey;
    }

    private void FixedUpdate()
    {
        GroundTest();
        ClimbTest();

        if (_jumpKey && _grounded)
        {
            //set vertical velocity to jump velocity
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpVelocity);
        }
        if(!_grounded & _canClimb)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _direction.y * _climbVelocity);
        }

        _rb.AddForce(new Vector2(_direction.x * (_moveForce - Mathf.Abs(_rb.velocity.x)) * (_grounded | _canClimb ? _moveAccelleration : 0.2f), ((_rb.velocity.y > 0) ? _direction.y * _jumpForce : 0)));

        _direction = Vector2.zero;
        _jumpKey = false;
    }

    private void GroundTest()
    {
        _grounded = Physics2D.CircleCast(transform.position, 0.4f, Vector3.down, _collider.bounds.extents.y + 0.1f, LayerUtility.TerrainMask);
    }
    private void ClimbTest()
    {
        _canClimb = Physics2D.Raycast(transform.position + new Vector3(0, 0.5f, 0), Vector3.down, 0.5f, LayerUtility.ClimbMask);

        _rb.gravityScale = (!_grounded & _canClimb) ? 0 : 1;
    }
}
