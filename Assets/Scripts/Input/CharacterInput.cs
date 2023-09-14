using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class CharacterInput : MonoBehaviour
{
    public Character Current;

    private void Update()
    {
        if (!TryGetController(out CharacterMovement characterController) && characterController.enabled) { return; }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical   = Input.GetAxisRaw("Vertical");

        characterController.OnMove(new Vector2(horizontal, vertical), Input.GetKeyDown(KeyCode.W) | Input.GetKeyDown(KeyCode.Space));
    }

    private bool TryGetController(out CharacterMovement controller)
    {
        controller = Current?.GetController();
        return controller != null;
    }
}
