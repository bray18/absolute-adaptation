using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabStick : MonoBehaviour
{
    /*
    private Rigidbody2D rb;
    public string prefabType = "Type1"; // Assign this in the inspector to differentiate prefab types

    void Start()
    {
        // Get the Rigidbody2D component of the prefab
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object has a PrefabStick component
        PrefabStick other = collision.gameObject.GetComponent<PrefabStick>();

        // If the other object does not have a PrefabStick component or has a different type, stick to it
        if (other == null || other.prefabType != this.prefabType)
        {
            // Immediately stop all movement
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;

            // Disable the Rigidbody2D to make the object stick and not respond to physics
            rb.isKinematic = true;
        }
        // Otherwise, they are equal prefabs, and you might want to handle combining them here or elsewhere
    }
    */
}