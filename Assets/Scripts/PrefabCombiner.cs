using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabCombiner : MonoBehaviour
{
    // Method to combine two prefabs
    public static void CombinePrefabs(GameObject prefabA, GameObject prefabB)
    {
        PrefabLevel prefabALevel = prefabA.GetComponent<PrefabLevel>();
        PrefabLevel prefabBLevel = prefabB.GetComponent<PrefabLevel>();
        Rigidbody2D rbA = prefabA.GetComponent<Rigidbody2D>();
        Rigidbody2D rbB = prefabB.GetComponent<Rigidbody2D>();

        // Check if both prefabs have levels and Rigidbody2D components
        if (prefabALevel != null && prefabBLevel != null && rbA != null && rbB != null && prefabALevel.level == prefabBLevel.level && prefabALevel.level < 7)
        {
            //play random sound between Pop1, Pop2, Pop3, and Pop4 that are in the scene
            int randomSound = Random.Range(1, 5);
            AudioSource audioSource = GameObject.Find("Pop" + randomSound).GetComponent<AudioSource>();
            audioSource.Play();

            // Calculate the midpoint between the two prefabs
            Vector2 midpoint = (prefabA.transform.position + prefabB.transform.position) / 2;

            // Calculate the average velocity
            Vector2 averageVelocity = (rbA.velocity + rbB.velocity) / 2;

            // Instantiate the next level prefab at the midpoint position
            GameObject newPrefab = Instantiate(prefabALevel.nextLevelPrefab, midpoint, Quaternion.identity);

            // Get the Rigidbody2D component of the new prefab and apply the average velocity
            Rigidbody2D newPrefabRb = newPrefab.GetComponent<Rigidbody2D>();
            if (newPrefabRb != null)
            {
                newPrefabRb.velocity = averageVelocity;
            }

            // Destroy the old prefabs
            Destroy(prefabA);
            Destroy(prefabB);
        }
    }
}