using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrefabCollisionCombiner : MonoBehaviour
{
    // Public fields to set from the Unity Editor
    public GameObject glitchEffectPrefab; // Drag your glitch effect prefab here
    public bool enableSceneSwitch = false; // Check this to enable scene switching
    public string sceneToSwitchTo; // Name of the scene to switch to

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
        if (glitchEffectPrefab != null)
        {
            // Activate the glitch effect
            StartGlitch();
        }

        // After the glitch effect, check if scene switching is enabled
        if (enableSceneSwitch)
        {
            SceneManager.LoadScene(sceneToSwitchTo);
        }
    }
}
