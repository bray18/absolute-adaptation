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
                _instance = FindObjectOfType<CombinationTracker>();
                if (_instance == null)
                {
                    var singletonObject = new GameObject("CombinationTracker");
                    _instance = singletonObject.AddComponent<CombinationTracker>();
                }
            }
            return _instance;
        }
    }

    private Dictionary<int, int> levelCombinations = new Dictionary<int, int>();
    public int animalLevelToTrack = 0; // Public variable to specify the animal level to track
    private int animalLevelCount = 0; // Variable to count the specified level of animal

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

        // Increment animal level count if this level matches the one to track
        if (level == animalLevelToTrack)
        {
            animalLevelCount++;
        }

        ScoreManager.Instance.AddScoreForLevelCombination(level);
        CheckForGameEvents(level);
    }

    public void ResetCombinations()
    {
        levelCombinations.Clear();
        animalLevelCount = 0; // Reset the animal level count as well
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

    public int GetAnimalLevelCount()
    {
        return animalLevelCount; // Method to access the animal level count
    }
}
