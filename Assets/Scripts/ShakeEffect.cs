using UnityEngine;
using System.Collections;

public class ShakeEffect : MonoBehaviour
{
    // Shake parameters
    public float shakeDuration = 0.5f;
    public float shakeMagnitude = 0.5f;

    private Vector3 originalPosition;
    private float currentShakeDuration;

    void Awake()
    {
        originalPosition = transform.localPosition;
    }

    void Update()
    {
        // Trigger shake with a left mouse click
        if (Input.GetMouseButtonDown(0))
        {
            StartShake();
        }

        // Shake effect
        if (currentShakeDuration > 0)
        {
            transform.localPosition = originalPosition + Random.insideUnitSphere * shakeMagnitude;
            currentShakeDuration -= Time.deltaTime;
        }
        else
        {
            currentShakeDuration = 0f;
            transform.localPosition = originalPosition;
        }
    }


    public void StartShake()
    {
        currentShakeDuration = shakeDuration;
    }
}
