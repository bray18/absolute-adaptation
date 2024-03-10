using System.Collections;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public int fadeOutSeconds = 3; // Public variable to set fade-out duration in seconds.
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("FadeOut script requires a SpriteRenderer component on the same GameObject.");
            return;
        }
        StartCoroutine(FadeOutOpacity());
    }

    IEnumerator FadeOutOpacity()
    {
        float elapsedTime = 0;
        Color currentColor = spriteRenderer.color;

        while (elapsedTime < fadeOutSeconds)
        {
            elapsedTime += Time.deltaTime;
            float alpha = 1 - Mathf.Clamp01(elapsedTime / fadeOutSeconds); // Invert the fade to decrease alpha over time
            spriteRenderer.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
            yield return null; // Wait until the next frame.
        }
    }
}
