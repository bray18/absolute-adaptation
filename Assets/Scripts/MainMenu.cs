using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    AudioSource audioSource;
    public void StartGame() {
        SceneManager.LoadScene("LevelSelect");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindWithTag("Music2") != null)
        {
            audioSource = GameObject.FindWithTag("Music2").GetComponent<AudioSource>();

            //Debug.Log("audiosource defined");

            Singleton.Instance.StopAudio();
            GameObject.Destroy(GameObject.FindWithTag("Music2"));

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}