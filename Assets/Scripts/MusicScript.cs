using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicScript : MonoBehaviour
{
    
    //void StopMusic(UnityEngine.AudioSource audioSource) {
    //    Singleton.Instance.StopAudio(audioSource);
    //}
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        
        //var audioPlayer = findObjectWithTag("Music").GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //if(SceneManager.GetActiveScene ().name == "Cutscene1") {
        //    var audio = GameObject.FindWithTag("Music").GetComponent<AudioSource>();
        //    StopMusic(audio);
        //}
    }
}
