using UnityEngine;

public class MusicStarter : MonoBehaviour
{
    public int trackNumber; // Assign this in the Inspector based on the desired track for the scene

    void Start()
    {
        if (Singleton.Instance.getCurrentTrackNumber() != trackNumber)
        {
            Singleton.Instance.GoAudio(trackNumber);
        }
    }
}