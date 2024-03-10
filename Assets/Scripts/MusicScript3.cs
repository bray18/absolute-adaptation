using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMusicController : MonoBehaviour
{
    public int trackNumber = 1; // The track number to play for this level
    void Start()
    {
        // Example: Stop music then Change to track number 1 for this level
        AudioSource audioSource = Singleton.Instance.gameObject.GetComponent<AudioSource>();
        Singleton.Instance.StopAudio();
        Singleton.Instance.GoAudio(trackNumber);
        
    }
}