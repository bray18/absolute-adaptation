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

        // Check if both prefabs are at the same level and not at max level
        if (prefabALevel != null && prefabBLevel != null && prefabALevel.level == prefabBLevel.level && prefabALevel.level < 7)
        {
            // Calculate the midpoint between the two prefabs
            Vector2 midpoint = (prefabA.transform.position + prefabB.transform.position) / 2;

            // Instantiate the next level prefab at the midpoint position
            GameObject newPrefab = Instantiate(prefabALevel.nextLevelPrefab, midpoint, Quaternion.identity);

            // Destroy the old prefabs
            Destroy(prefabA);
            Destroy(prefabB);
        }
    }
}