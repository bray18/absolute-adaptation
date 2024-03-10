using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrefabCollisionCombiner : MonoBehaviour
{
    private string sceneToSwitchTo = "Win6"; // Default scene to switch to

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.GetInstanceID() < collision.gameObject.GetInstanceID())
        {
            PrefabLevel thisPrefabLevel = gameObject.GetComponent<PrefabLevel>();
            PrefabLevel otherPrefabLevel = collision.gameObject.GetComponent<PrefabLevel>();

            if (otherPrefabLevel != null)
            {
                PrefabCombiner.CombinePrefabs(gameObject, collision.gameObject);
            }
        }
    }
    // Public method to set the scene to switch to
    public void SetSceneToSwitchTo(string newSceneName)
    {
        sceneToSwitchTo = newSceneName;
    }
}
