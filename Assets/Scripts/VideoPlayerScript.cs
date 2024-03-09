using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video; // Ensure this namespace is included for video functionality

public class VideoPlayerScript : MonoBehaviour
{
    public VideoClip videoClip; // Public variable for the video clip

    AudioSource audioSource;
    
    // This method is called when the video reaches its end
    void EndReached(VideoPlayer vp) {
        Debug.Log("End reached");
        SceneManager.LoadScene("BasicLevel"); // Load the scene named "BasicLevel"
    }

    void Start()
    {
        audioSource = GameObject.FindWithTag("Music").GetComponent<AudioSource>();

        // Stop the audio using the Singleton pattern
        Singleton.Instance.StopAudio(audioSource);

        // Find the Main Camera GameObject
        GameObject camera = GameObject.Find("Main Camera");
        // Add a VideoPlayer component to the Main Camera
        var videoPlayer = camera.AddComponent<VideoPlayer>();

        // Assign the public video clip to the video player
        videoPlayer.clip = videoClip;

        // Configure the video player
        videoPlayer.renderMode = VideoRenderMode.CameraNearPlane; // Render on the camera's near plane
        videoPlayer.waitForFirstFrame = true; // Wait for the first frame before starting playback
        videoPlayer.loopPointReached += EndReached; // Subscribe to the loopPointReached event
        videoPlayer.Play(); // Start playing the video
    }

    // Update is called once per frame
    void Update()
    {
        // This can be used for any frame-dependent logic
    }
}
