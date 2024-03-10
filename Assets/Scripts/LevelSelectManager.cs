using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour
{
    AudioSource audioSource;
    // Start is called before the first frame update
    public void StartLevel1() {
        SceneManager.LoadScene("Cutscene1");
    }
    
    void Start()
    {

        /*if (GameObject.FindWithTag("Music2") != null)
        {
            audioSource = GameObject.FindWithTag("Music2").GetComponent<AudioSource>();

            //audioSource = GameObject.FindWithTag("Music2").GetComponent<AudioSource>();

            Singleton.Instance.StopAudio(audioSource);
            GameObject.Destroy(GameObject.FindWithTag("Music"));

        }
        if (!GameObject.FindWithTag("Music").GetComponent<AudioSource>().isPlaying)
        {
            audioSource = GameObject.FindWithTag("Music").GetComponent<AudioSource>();
            audioSource.Play();
            

        }*/
        if (GameObject.FindWithTag("Music2") != null)
        {
            if(GameObject.FindWithTag("Music2").GetComponent<AudioSource>().isPlaying)
            {
                audioSource = GameObject.FindWithTag("Music2").GetComponent<AudioSource>();
                Singleton.Instance.StopAudio(audioSource);
            }
        }
        
        if(!GameObject.FindWithTag("Music").GetComponent<AudioSource>().isPlaying)
        {
            audioSource = GameObject.FindWithTag("Music").GetComponent<AudioSource>();
            audioSource.Play();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
