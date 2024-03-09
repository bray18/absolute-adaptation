using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabCollisionCombiner : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Ensure that this object is the one with the lower instance ID
        if (gameObject.GetInstanceID() < collision.gameObject.GetInstanceID())
        {
            // Check if the collided object also has a PrefabLevel component
            PrefabLevel otherPrefabLevel = collision.gameObject.GetComponent<PrefabLevel>();
            if (otherPrefabLevel != null)
            {
                // Call the CombinePrefabs method
                PrefabCombiner.CombinePrefabs(gameObject, collision.gameObject);
            }
        }
    }
}
