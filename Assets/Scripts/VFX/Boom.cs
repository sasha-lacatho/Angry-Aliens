using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Boom : MonoBehaviour
{

    [SerializeField] public VisualEffect Particule;
    
    private void Awake()
    {
        Particule.Stop();
    }

    private void Start()
    {
        Particule.Play();

        if (Camera.main.TryGetComponent(out CameraController camController))
        {
            camController.StartExplosion();
        }
    }
}