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
            // Instantiate the next level prefab
            GameObject newPrefab = Instantiate(prefabALevel.nextLevelPrefab, prefabA.transform.position, Quaternion.identity);

            // Optional: Adjust the position/rotation/scale of the newPrefab as needed

            // Destroy the old prefabs
            Destroy(prefabA);
            Destroy(prefabB);
        }
    }
}
