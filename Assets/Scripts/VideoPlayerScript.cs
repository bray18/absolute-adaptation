using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VideoPlayerScript : MonoBehaviour
{
    
    
    
    // Start is called before the first frame update
    
    void Start()
    {
        GetComponent<UnityEngine.Video.VideoPlayer>().Play();
        
    }

    // Update is called once per frame
    void Update()
    {   
        
    }
}
