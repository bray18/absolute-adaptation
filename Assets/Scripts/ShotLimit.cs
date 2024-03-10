using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ShotLimit : MonoBehaviour
{
    public int maxShots = 10; // Maximum number of shots allowed
    public TextMeshProUGUI shotText; // Assign the TextMeshProUGUI component in the Inspector

    private int remainingShots; // Number of remaining shots

    private void Start()
    {
        // Initialize remaining shots to max shots
        remainingShots = maxShots;
        UpdateShotText();
    }

    private void UpdateShotText()
    {
        // Update UI text with the current shot count, but never display below 0
        if (shotText != null)
        {
            shotText.text = Mathf.Max(0, remainingShots).ToString(); // Display 0 even when remainingShots is -1
        }
    }

    public void DecreaseShot()
    {
        // Decrease remaining shots
        remainingShots--;
        UpdateShotText();

        // If remaining shots is below 0 after decrease, load the GameOver scene
        if (remainingShots < 0)
        {
            SceneManager.LoadScene("GameOver"); // Load the GameOver scene
        }
    }

    public void IncreaseShots(int amount)
    {
        // Increase shot count and clamp to maximum
        remainingShots += amount;
        if (remainingShots > maxShots)
        {
            remainingShots = maxShots;
        }
        UpdateShotText();
    }
}
