using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrefabCollisionCombiner : MonoBehaviour
{
    private string sceneToSwitchTo = "Win6"; // Name of the scene to switch to

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.GetInstanceID() < collision.gameObject.GetInstanceID())
        {
            PrefabLevel thisPrefabLevel = gameObject.GetComponent<PrefabLevel>();
            PrefabLevel otherPrefabLevel = collision.gameObject.GetComponent<PrefabLevel>();

            if (otherPrefabLevel != null)
            {
                if (thisPrefabLevel.level == 7 || otherPrefabLevel.level == 7)
                {
                    StartCoroutine(HandleLevel7Touch());
                }
                else
                {
                    PrefabCombiner.CombinePrefabs(gameObject, collision.gameObject);
                }
            }
        }
    }

    private IEnumerator HandleLevel7Touch()
    {
        // Optionally wait for a short duration before switching scenes
        yield return new WaitForSeconds(1.0f); // Waits for 1 second before executing the next line

        SceneManager.LoadScene(sceneToSwitchTo);

        // No need for a return statement after a yield in a coroutine
    }
}