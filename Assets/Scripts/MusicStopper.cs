using UnityEngine;

public class MusicStopper : MonoBehaviour
{
    void Start()
    {
        // Assuming Singleton has an AudioSource or manages an AudioSource
        AudioSource audioSource = Singleton.Instance.gameObject.GetComponent<AudioSource>();
        if (audioSource.isPlaying)
        {
            Singleton.Instance.StopAudio();
        }
    }
}
