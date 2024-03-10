using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    public static Singleton Instance { get; private set; }

    //ublic bool previousWasMenu = false;

    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } else { 
            Instance = this; 
        } 
        DontDestroyOnLoad(this.gameObject);
    }

    public void StopAudio(AudioSource audioSource)
    {
        Debug.Log("In singleton stopaudio");
        audioSource.Stop();
    }
    public void GoAudio(AudioSource audioSource)
    {
        audioSource.Play();
    }
    /*
    public void PreviousScene()
    {
        if(gameObject.scene.name == "Menu")
        {
            previousWasMenu = true;
        } else
        {
            previousWasMenu= false;
        }
    }
    public bool GetPreviousScene()
    {
        return previousWasMenu;
    }
    */
}
