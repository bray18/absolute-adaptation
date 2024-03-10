using System.Collections;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    public int fadeInSeconds = 30; // Public variable to set fade-in duration in seconds.
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("FadeIn script requires a SpriteRenderer component on the same GameObject.");
            return;
        }
        StartCoroutine(FadeInOpacity());
    }

    IEnumerator FadeInOpacity()
    {
        float elapsedTime = 0;
        Color currentColor = spriteRenderer.color;

        while (elapsedTime < fadeInSeconds)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / fadeInSeconds);
            spriteRenderer.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
            yield return null; // Wait until the next frame.
        }
    }
}
