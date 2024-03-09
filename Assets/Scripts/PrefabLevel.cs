using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabLevel : MonoBehaviour
{
    public int level = 1; // Current level of the prefab
    public GameObject nextLevelPrefab; // Assign this in the inspector to the next level prefab
}
