using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class CannonShooter : MonoBehaviour
{
    public GameObject[] prefabs; // Assign prefabs in the Inspector
    public float shootForce = 1000f; // Adjust based on your needs
    private Queue<int> backlogIndexes = new Queue<int>(); // Stores indexes of prefabs
    public int[] prefabWeights; // Assign weights in the Inspector

    private GameObject currentPreview; // Currently displayed preview
    private Vector3 previewScale = new Vector3(0.1f, 0.1f, 1f); // Scale for the preview
    public int backlogSize = 5; // Size of the backlog

    // Sound
    public AudioClip shootSound; // Assign in the Inspector
    private AudioSource audioSource; // AudioSource component

    private void Start()
    {
        FillBacklog();
        UpdatePreview();
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component
        CombinationTracker.Instance.ResetCombinations(); // Reset the combination counts
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button pressed
        {
            ShootPrefab();
            UpdateBacklog();
            UpdatePreview();
            PlayShootSound(); // Play shoot sound
        }
    }

    void ShootPrefab()
    {
        if (currentPreview != null)
        {
            // Instantiate new object for shooting
            GameObject toShoot = Instantiate(prefabs[backlogIndexes.Peek()], new Vector3(0, 0, 1), Quaternion.identity); // Set Z to 1
            Vector3 shootingDirection = CalculateShootingDirection();
            toShoot.GetComponent<Rigidbody2D>().AddForce(shootingDirection * shootForce);
            // No need to adjust scale here, as the object is instantiated with its original scale
        }
    }

    void FillBacklog()
    {
        for (int i = 0; i < backlogSize; i++)
        {
            backlogIndexes.Enqueue(SelectPrefabIndexBasedOnWeight());
        }
    }

    void UpdateBacklog()
    {
        backlogIndexes.Dequeue(); // Remove the first element, which was just shot
        backlogIndexes.Enqueue(SelectPrefabIndexBasedOnWeight()); // Add a new weighted index to the backlog
    }

    int SelectPrefabIndexBasedOnWeight()
    {
        int totalWeight = 0;
        foreach (int weight in prefabWeights)
        {
            totalWeight += weight;
        }

        int randomNumber = Random.Range(1, totalWeight + 1);
        int runningSum = 0;
        for (int i = 0; i < prefabWeights.Length; i++)
        {
            runningSum += prefabWeights[i];
            if (randomNumber <= runningSum)
            {
                return i;
            }
        }

        return 0; // Default return value in case of error
    }


    void UpdatePreview()
    {
        if (currentPreview != null) Destroy(currentPreview);

        int nextIndex = backlogIndexes.Peek(); // Get the next prefab index without removing it
        currentPreview = Instantiate(prefabs[nextIndex], new Vector3(0, 0, 1), Quaternion.identity); // Set Z to 1
        currentPreview.GetComponent<Rigidbody2D>().simulated = false; // Stop physics simulation for the preview
        currentPreview.transform.localScale = previewScale; // Apply preview scale
    }

    Vector3 CalculateShootingDirection()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Ensure it's on the same plane
        return (mousePosition - Vector3.zero).normalized;
    }

    void PlayShootSound()
    {
        if (audioSource != null && shootSound != null)
        {
            audioSource.PlayOneShot(shootSound); // Play the shoot sound
        }
    }
}