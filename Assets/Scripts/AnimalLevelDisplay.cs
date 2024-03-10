using UnityEngine;
using TMPro; // Make sure to include the TextMeshPro namespace

public class AnimalLevelDisplay : MonoBehaviour
{
    public TextMeshProUGUI textDisplay; // Assign this in the Inspector

    void Update()
    {
        // Update the TextMeshPro text with the current animal level count
        textDisplay.text = CombinationTracker.Instance.GetAnimalLevelCount().ToString();
    }
}
