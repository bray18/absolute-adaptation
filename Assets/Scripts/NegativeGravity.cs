using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegativeGravity : MonoBehaviour
{
    public float gravityStrength = 10f; // Adjust the strength of the "negative gravity"

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ApplyNegativeGravity();
    }

    void ApplyNegativeGravity()
    {
        // Calculate direction from center to the current position
        Vector2 directionFromCenter = (transform.position - Vector3.zero).normalized;

        // Apply force in that direction
        rb.AddForce(directionFromCenter * gravityStrength, ForceMode2D.Force);
    }
}