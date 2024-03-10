using UnityEngine;
using System.Collections.Generic;

public class CombinationTracker : MonoBehaviour
{
    private static CombinationTracker _instance;
    public static CombinationTracker Instance
    {
        get
        {
            if (_instance == null)
            {
                // Find existing instance in the scene
                _instance = FindObjectOfType<CombinationTracker>();
                if (_instance == null)
                {
                    // Create new instance if one doesn't already exist
                    var singletonObject = new GameObject("CombinationTracker");
                    _instance = singletonObject.AddComponent<CombinationTracker>();
                }
            }
            return _instance;
        }
    }

    private Dictionary<int, int> levelCombinations = new Dictionary<int, int>();

    // Ensure the instance is unique (optional)
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Debug.LogWarning("Another instance of CombinationTracker was found! Destroying...");
            Destroy(gameObject);
        }
    }

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

        // Assuming ScoreManager follows a similar singleton pattern
        ScoreManager.Instance.AddScoreForLevelCombination(level);
        CheckForGameEvents(level);
    }

    public void ResetCombinations()
    {
        levelCombinations.Clear();
    }

    private void CheckForGameEvents(int level)
    {
        if (level == 5 && levelCombinations[level] == 1)
        {
            Debug.Log("Level 5 combination achieved! Triggering event...");
        }
    }

    public int GetCombinationCount(int level)
    {
        return levelCombinations.ContainsKey(level) ? levelCombinations[level] : 0;
    }
}
