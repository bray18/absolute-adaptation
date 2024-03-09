using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Include the TextMeshPro namespace

public class CountdownTimer : MonoBehaviour
{
    public float countdownTime = 60f;
    private float currentTime;

    public TMP_Text countdownText; // Reference to a TextMeshPro UI element
    public AudioSource alarmSound; // Reference to an AudioSource for the alarm sound

    public int warningTime = 10; // Time in seconds to start warning
    private bool alarmPlaying = false;
    private int timesToPlayAlarm; // Times the alarm should play, based on the 'warningTime' length

    void Start()
    {
        currentTime = countdownTime;
        timesToPlayAlarm = warningTime; // Initialize with warningTime value
    }

    void Update()
    {
        currentTime -= Time.deltaTime;

        if (countdownText != null)
        {
            countdownText.text = currentTime.ToString("0");
        }

        // When countdown is below warningTime, change text color and play alarm
        if (currentTime <= warningTime && !alarmPlaying)
        {
            ChangeTextColor(); // Call a method to change text color to red gradient
            alarmPlaying = true; // Prevents multiple triggers
        }

        // Logic to play the alarm sound once per second
        if (alarmPlaying && timesToPlayAlarm > 0)
        {
            // Play the sound once per second
            if (!alarmSound.isPlaying)
            {
                alarmSound.Play();
                timesToPlayAlarm--;
            }
        }

        if (currentTime <= 0)
        {
            currentTime = 0;
            SceneManager.LoadScene("GameOver");
        }
    }

    void ChangeTextColor()
    {
        // Example gradient from white to red. You can customize the gradient as needed.
        Color darkRed = new Color(139f / 255f, 0f / 255f, 0f / 255f);
        var gradient = new VertexGradient(Color.red, Color.red, darkRed, darkRed);
        countdownText.colorGradient = gradient;
    }
}
