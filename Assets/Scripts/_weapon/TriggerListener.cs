using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerListener : MonoBehaviour
{
    public Collider2D Collider;
    public Action<Collider2D> OnTrigger;


    private void Start()
    {
        Collider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnTrigger(collision);
    }
}
