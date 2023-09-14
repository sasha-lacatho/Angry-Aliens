using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Boom : MonoBehaviour
{

    [SerializeField] private CameraController cameraController;
    [SerializeField] public VisualEffect Particule;
    
    private void Awake()
    {
        Particule.Stop();
    }

    private void StartEplosion()
    {
        Particule.Play();
        cameraController.StartExplosion();
    }
}
