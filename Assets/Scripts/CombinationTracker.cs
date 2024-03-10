using UnityEngine;
using System.Collections.Generic;

public class CombinationTracker : MonoBehaviour
{
    // Singleton instance for easy access
    public static CombinationTracker Instance { get; private set; }

    // Dictionary to track the number of combinations for each level
    private Dictionary<int, int> levelCombinations = new Dictionary<int, int>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Increment the combination count for a given level
    public void IncrementCombinationCount(int level)
    {
        if (levelCombinations.ContainsKey(level))
        {
            levelCombinations[level]++;
        }
        else
        {
            levelCombinations[level] = 1;
        }

        // Check for specific game events
        CheckForGameEvents(level);
    }

    // Reset the combination counts
    public void ResetCombinations()
    {
        levelCombinations.Clear();
    }

    // Check for specific game events based on the combination level
    private void CheckForGameEvents(int level)
    {
        // Example: End the level when a level 5 combination is achieved
        if (level == 5 && levelCombinations[level] == 1) // Adjust based on your specific needs
        {
            // End the level or trigger any specific event
            Debug.Log("Level 5 combination achieved! Triggering event...");
            // Add your event triggering code here
        }
    }

    // Optional: Method to get the combination count for a specific level
    public int GetCombinationCount(int level)
    {
        if (levelCombinations.ContainsKey(level))
        {
            return levelCombinations[level];
        }
        return 0;
    }
}
