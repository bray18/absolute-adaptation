using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour
{
    // Assuming each level has a designated track number
    // Example mapping: Level 1 -> Track 1, etc.
    
    void Start()
    {
        // Setup the audio for the level select scene
        SetupLevelSelectAudio();
    }

    // Method to setup audio for level select scene
    private void SetupLevelSelectAudio()
    {
        AudioSource audioSource = Singleton.Instance.gameObject.GetComponent<AudioSource>();
        if(audioSource == null) {
            Debug.LogError("Singleton does not have an AudioSource component.");
            return;
        }

        // Determine if we need to change the music for the level select screen
        if (!audioSource.isPlaying)
        {
            // Example: Assuming track 0 is for the Menu/Level Select
            Singleton.Instance.GoAudio(0); // Play using the new system
        }
    }

    // Loads the cutscene and updates the music track accordingly
    public void StartLevel(int levelNumber, string cutsceneSceneName)
    {
        // Adjust the music for the level
        AudioSource audioSource = Singleton.Instance.gameObject.GetComponent<AudioSource>();
        //Singleton.Instance.SetMusicTrack(levelNumber); // Assumes level number matches track number
        Singleton.Instance.GoAudio(levelNumber); // Play new track

        // Load the cutscene
        SceneManager.LoadScene(cutsceneSceneName);
    }

    // Specific level start methods can call StartLevel with appropriate parameters
    public void StartLevel1() {
        StartLevel(1, "Cutscene1");
    }
    public void StartLevel2() {
        StartLevel(2, "Cutscene2");
    }
    public void StartLevel3() {
        StartLevel(3, "Cutscene3");
    }
    public void StartLevel4() {
        StartLevel(4, "Cutscene4");
    }
    public void StartLevel5() {
        StartLevel(5, "Cutscene5");
    }
    public void StartLevel6() {
        StartLevel(6, "Cutscene6");
    }
    public void StartLevel7() {
        StartLevel(7, "Cutscene7");
    }

    // Update is not modified but included for completeness
    void Update()
    {
        
    }
}
