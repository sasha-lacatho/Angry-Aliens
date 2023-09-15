using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private AnimationCurve shakeCurve;

    private Vector3 targetPosition;
    private Vector3 offset;
    
    private void Awake()
    {
        targetPosition = transform.position;
    }


    public void StartExplosion()
    {
        StartCoroutine(ScreenShake());
    }

    private IEnumerator ScreenShake()
    {
        Debug.Log("ScreenShake");
        for(float t = 0; t < 0.5f; t += Time.deltaTime)
        {
            Debug.Log(t);
            float y = shakeCurve.Evaluate(t * 2.0f);
            offset = new Vector3(0.0f, y, 0.0f);

            transform.position = targetPosition + offset;

            yield return null;
        }

        offset = Vector3.zero;
        transform.position = targetPosition;
    }
}
