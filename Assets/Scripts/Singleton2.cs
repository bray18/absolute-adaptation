using UnityEngine;

public class Singleton2<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                // Find an existing instance in the scene
                _instance = FindObjectOfType<T>();
                if (_instance == null)
                {
                    // Create a new GameObject and add the singleton component if no instance exists
                    GameObject singletonObject = new GameObject(typeof(T).Name);
                    _instance = singletonObject.AddComponent<T>();
                }
            }
            return _instance;
        }
    }

    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            // Uncomment the next line if the singleton should persist across scene changes
            // DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }
}
