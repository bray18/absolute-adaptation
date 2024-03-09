using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabCollisionCombiner : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object also has a PrefabLevel component
        if (collision.gameObject.GetComponent<PrefabLevel>() != null)
        {
            // Call the CombinePrefabs method
            PrefabCombiner.CombinePrefabs(gameObject, collision.gameObject);
        }
    }
}