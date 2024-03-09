using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subscriber : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable ()
	{
        MusicScript.Publish += Destroy;
	}

	void OnDisable ()
	{
        MusicScript.Publish -= Destroy;
	}

	void Destroy ()
	{
		Destroy (transform.gameObject);
	}
    
}
