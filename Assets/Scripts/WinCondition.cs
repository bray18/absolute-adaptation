using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // Required for using Coroutines

public class WinCondition : MonoBehaviour
{
    public int winLevel; // The level that needs to be reached to win
    public int winCombinationCount; // The number of combinations needed to win at that level
    public string winSceneName; // The name of the scene to load upon winning
    public int winDelay; // The delay in seconds before loading the win scene
    public PrefabCollisionCombiner prefabCollisionCombiner; // Reference to the PrefabCollisionCombiner script

    private void Update()
    {
        // Check the current combination count for the winLevel
        if (CombinationTracker.Instance.GetCombinationCount(winLevel) >= winCombinationCount)
        {
            if (winLevel == 7)
            {
                // For level 7, dynamically decide the scene to switch to before starting the coroutine
                DecideAndSetSceneToSwitchForLevel7();
            }
            else
            {
                // Win condition met for levels other than 7, start the coroutine to load the win scene after a delay
                StartCoroutine(WaitAndLoadScene(winSceneName));
            }
        }
    }

    IEnumerator WaitAndLoadScene(string sceneName)
    {
        Debug.Log("Win condition met. Waiting " + winDelay + " seconds before loading win scene...");
        yield return new WaitForSeconds(winDelay); // Wait for the specified delay
        SceneManager.LoadScene(sceneName);
    }

    // Method to dynamically decide and set the scene to switch to for level 7
    private void DecideAndSetSceneToSwitchForLevel7()
    {
        string sceneToSwitchTo = ""; // Initialize with an empty string
        // Example logic based on the current scene or other conditions
        string currentSceneName = SceneManager.GetActiveScene().name;
        
        // Customize this logic based on your game's requirements
        if (currentSceneName == "Level6")
        {
            sceneToSwitchTo = "Win6";
        }
        else if (currentSceneName == "Level7")
        {
            sceneToSwitchTo = "Win7";
        }
        // Add more conditions as needed
        else
        {
            sceneToSwitchTo = "Menu"; // A default scene if none of the conditions match
        }

        // Assuming prefabCollisionCombiner is correctly assigned in the inspector
        if (prefabCollisionCombiner != null)
        {
            prefabCollisionCombiner.SetSceneToSwitchTo(sceneToSwitchTo);
            StartCoroutine(WaitAndLoadScene(sceneToSwitchTo)); // Use the dynamically set scene
        }
        else
        {
            //Debug.LogError("PrefabCollisionCombiner reference not set in WinCondition.");
        }
    }
}
