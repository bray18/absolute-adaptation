using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VideoPlayerScript : MonoBehaviour
{
    
    
    
    // Start is called before the first frame update
    void CheckOver(){
        if(!GetComponent<UnityEngine.Video.VideoPlayer>().isPlaying) {
            SceneManager.LoadScene("BasicLevel");
        }
    }
    void Start()
    {
        GetComponent<UnityEngine.Video.VideoPlayer>().Play();
        UnityEngine.Video.VideoPlayer.loopPointReached += CheckOver;
    }

    // Update is called once per frame
    void Update()
    {   
        
    }
}
