using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    public static Singleton Instance { get; private set; }

    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } else { 
            Instance = this; 
        } 
        DontDestroyOnLoad(this.gameObject);
    }

    public void StopAudio(AudioSource audioSource)
    {
        audioSource.Pause();
    }
    public void GoAudio(AudioSource audioSource)
    {
        audioSource.Play();
    }

}
