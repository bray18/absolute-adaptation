using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GlitchEffect : MonoBehaviour
{
    public Image glitchOverlay;
    public float glitchDuration = 1.0f;
    private bool isGlitching = false;

    public void StartGlitch()
    {
        if (!isGlitching)
        {
            StartCoroutine(GlitchRoutine());
        }
    }

    private IEnumerator GlitchRoutine()
    {
        isGlitching = true;
        float endTime = Time.time + glitchDuration;

        while (Time.time < endTime)
        {
            glitchOverlay.enabled = !glitchOverlay.enabled;
            yield return new WaitForSeconds(Random.Range(0.05f, 0.15f));

            // Optional: Manipulate other properties like color or add more effects
        }

        glitchOverlay.enabled = false;
        isGlitching = false;
    }
}
