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
            StartCoroutine(WaitAndLoadScene(winSceneName));
        }
    }

    IEnumerator WaitAndLoadScene(string sceneName)
    {
        Debug.Log("Win condition met. Waiting " + winDelay + " seconds before loading win scene...");
        yield return new WaitForSeconds(winDelay); // Wait for the specified delay
        SceneManager.LoadScene(sceneName);
    }

}
