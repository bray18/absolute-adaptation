using UnityEngine;
using System.Collections;

public class ConditionalObjectAppearance : MonoBehaviour
{
    // Reference to the WinCondition script to access the win condition status
    public WinCondition winCondition;

    // Fade in parameters
    public float fadeInDuration = 1.0f; // Duration of the fade in effect

    private SpriteRenderer spriteRenderer; // For 2D objects
    private bool hasStartedFadeIn = false; // To ensure fade in starts only once

    void Start()
    {
        // Initialize components
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Initially set the object to be fully transparent
        Color color = spriteRenderer.color;
        color.a = 0;
        spriteRenderer.color = color;

        // Optionally disable the object to not interact or be hit by anything
        gameObject.SetActive(false);
    }

    void Update()
    {
        // Check if the win condition is met and fade in has not started yet
        if (winCondition.winConditionMet && !hasStartedFadeIn)
        {
            // Set flag to true to prevent multiple fade in initiations
            hasStartedFadeIn = true;

            // Activate the object and start the fade-in effect
            gameObject.SetActive(true);
            StartCoroutine(FadeInObject());
        }
    }

    IEnumerator FadeInObject()
    {
        float elapsedTime = 0;
        Color color = spriteRenderer.color;

        while (elapsedTime < fadeInDuration)
        {
            // Update elapsed time
            elapsedTime += Time.deltaTime;

            // Calculate new alpha value
            color.a = Mathf.Clamp01(elapsedTime / fadeInDuration);
            spriteRenderer.color = color;

            yield return null;
        }
    }
}
