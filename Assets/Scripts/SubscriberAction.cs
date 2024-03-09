using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SubscriberAction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update()
    {
        Scene Cutscene1 = SceneManager.GetActiveScene ();

		string Cutscene = Cutscene1.name;

		if (Cutscene == "Example 1") 
		{
			transform.GetComponent<MusicScript>().PublishTheEvent();
		}
    }
}
