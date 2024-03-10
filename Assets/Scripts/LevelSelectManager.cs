using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour
{
    AudioSource audioSource;
    AudioSource audioSource2;
    // Start is called before the first frame update
    public void StartLevel1() {
        SceneManager.LoadScene("Cutscene1");
    }
    public void StartLevel2() {
        SceneManager.LoadScene("Cutscene2");
    }
    public void StartLevel3() {
        SceneManager.LoadScene("Cutscene3");
    }
    public void StartLevel4() {
        SceneManager.LoadScene("Cutscene4");
    }
    public void StartLevel5() {
        SceneManager.LoadScene("Cutscene5");
    }
    public void StartLevel6() {
        SceneManager.LoadScene("Cutscene6");
    }
    public void StartLevel7() {
        SceneManager.LoadScene("Cutscene7");
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
        if(Singleton.Instance.GetPreviousScene() == false)
        {
            audioSource = GameObject.FindWithTag("Music").GetComponent<AudioSource>();
            Singleton.Instance.GoAudio(audioSource);
            if(GameObject.FindWithTag("Music2")!=null)
            {
                Debug.Log("Music 2 was not null");
                audioSource2 = GameObject.FindWithTag("Music2").GetComponent<AudioSource>();
                Singleton.Instance.StopAudio(audioSource2);
            }
        }
        Singleton.Instance.PreviousScene();
        /*
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
            Singleton.Instance.GoAudio(audioSource);
        }
        */

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
