using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerListener : MonoBehaviour
{
    public Action<Collider2D> OnTrigger;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnTrigger(collision);
    }
}
