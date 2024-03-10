using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectiveScript : MonoBehaviour
{
    public string sceneName = "Menu";


    public void GoToGame()
    {
        Debug.Log("I AM NOW LOADING THESCENE IN GOTOGAME called.");
        SceneManager.LoadScene(sceneName);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
