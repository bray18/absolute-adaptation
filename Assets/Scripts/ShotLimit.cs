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
        remainingShots = maxShots;
        UpdateShotText();
    }

    private void UpdateShotText()
    {
        if (shotText != null)
        {
            shotText.text = remainingShots.ToString(); // Improved UI text
        }
    }

    public void DecreaseShot()
    {
        if (remainingShots > 0)
        {
            remainingShots--;
            UpdateShotText();
            if (remainingShots <= 0)
            {
                SceneManager.LoadScene("GameOver"); // Load the GameOver scene
            }
        }
    }

    public void IncreaseShots(int amount)
    {
        remainingShots += amount;
        if (remainingShots > maxShots)
        {
            remainingShots = maxShots;
        }
        UpdateShotText();
    }
}
