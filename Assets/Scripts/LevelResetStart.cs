using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelResetStart : MonoBehaviour
{

    void Start() {
    gameObject.SetActive(true); // If the GameObject was inactive
    GetComponent<LevelResetStart>().enabled = true; // If the script was disabled
}

    private void Awake()
    {
        Debug.Log("ScoreManager Awake called.");
    }

    void OnEnable()
    {
        Debug.Log("LevelResetStart OnEnable called.");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded called.");
        ScoreManager.Instance.ResetScore();
    }


}
