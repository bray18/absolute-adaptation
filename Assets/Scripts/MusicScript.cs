using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    public delegate void PublishEvent (); 
    public static event PublishEvent Publish;

    public void PublishTheEvent ()
	{
		if (Publish != null)
			Publish ();
	}
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        //var audioPlayer = findObjectWithTag("Music").GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
