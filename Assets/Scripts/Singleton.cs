using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    public static Singleton Instance { get; private set; }
    private int currentTrackNumber = -1;

    private AudioSource audioSource; // Integrated AudioSource to control music playback
    private string[] tracks = new string[11] { "Music/Menu", "Music/Level1", "Music/Level2", "Music/Level3", "Music/Level4", "Music/Level5", "Music/Level6", "Music/Level7", "Music/Loser", "Music/Menu", "Music/Menu" };

    void Start() {
  
    }
    private void Awake() 
    { 
        if (Instance != null && Instance != this) 
        {
            Destroy(gameObject);
        } 
        else 
        { 
            Instance = this; 
            DontDestroyOnLoad(gameObject);
            // Initialize the AudioSource component
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.loop = true; // Optional: Loop music if desired
        } 
    }

    // Stops the currently playing audio
    public void StopAudio()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    // Starts playing the audio track specified by trackNumber
    public void GoAudio(int trackNumber)
    {
        if (trackNumber >= 0 && trackNumber < tracks.Length)
        {
            if (currentTrackNumber != trackNumber) // Check if different track
            {
                Debug.Log("Playing track: " + tracks[trackNumber]);
                AudioClip clip = Resources.Load<AudioClip>(tracks[trackNumber]);
                if (clip != null)
                {
                    audioSource.clip = clip;
                    Debug.Log("Found clip: " + tracks[trackNumber]);
                    audioSource.Play();
                    Debug.Log("Playing audio: " + tracks[trackNumber]);
                    currentTrackNumber = trackNumber; // Update current track number
                    Debug.Log("Current track number: " + currentTrackNumber);
                }
                else
                {
                    Debug.LogError("Clip not found for track: " + tracks[trackNumber]);
                }
            }
        }
        else
        {
            Debug.LogError("Invalid track number");
        }
    }

    // Method to get the current track number
    public int getCurrentTrackNumber()
    {
        return currentTrackNumber;
    }


    // Optional: Call this method to change the track based on scene or other conditions
    public void ChangeTrack(int trackNumber)
    {
        StopAudio(); // Ensure the current track is stopped before starting a new one
        GoAudio(trackNumber);
    }
}
