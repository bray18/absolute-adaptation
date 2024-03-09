using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Include the TextMeshPro namespace

public class CountdownTimer : MonoBehaviour
{
    public float countdownTime = 60f;
    private float currentTime;

    // Update the type from 'Text' to 'TMP_Text'
    public TMP_Text countdownText; // Reference to a TextMeshPro UI element

    void Start()
    {
        currentTime = countdownTime;
    }

    void Update()
    {
        currentTime -= Time.deltaTime;
        
        // Update the TextMeshPro text with the countdown
        if (countdownText != null)
        {
            countdownText.text = currentTime.ToString("0");
        }

        if (currentTime <= 0)
        {
            currentTime = 0;
            SceneManager.LoadScene("GameOver");
        }
    }
}
