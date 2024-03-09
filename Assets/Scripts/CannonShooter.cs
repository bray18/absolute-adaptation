using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class CannonShooter : MonoBehaviour
{
    public GameObject[] prefabs; // Assign prefabs in the Inspector
    public float shootForce = 1000f; // Adjust based on your needs
    private Queue<int> backlogIndexes = new Queue<int>(); // Stores indexes of prefabs
    private GameObject currentPreview; // Currently displayed preview
    private Vector3 previewScale = new Vector3(0.1f, 0.1f, 1f); // Scale for the preview
    public int backlogSize = 5; // Size of the backlog

    private void Start()
    {
        FillBacklog();
        UpdatePreview();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button pressed
        {
            ShootPrefab();
            UpdateBacklog();
            UpdatePreview();
        }
    }

    void ShootPrefab()
    {
        if (currentPreview != null)
        {
            // Instantiate new object for shooting
            GameObject toShoot = Instantiate(prefabs[backlogIndexes.Peek()], Vector3.zero, Quaternion.identity);
            Vector3 shootingDirection = CalculateShootingDirection();
            toShoot.GetComponent<Rigidbody2D>().AddForce(shootingDirection * shootForce);
            // No need to adjust scale here, as the object is instantiated with its original scale
        }
    }

    void FillBacklog()
    {
        for (int i = 0; i < backlogSize; i++)
        {
            backlogIndexes.Enqueue(Random.Range(0, prefabs.Length));
        }
    }

    void UpdateBacklog()
    {
        backlogIndexes.Dequeue(); // Remove the first element, which was just shot
        backlogIndexes.Enqueue(Random.Range(0, prefabs.Length)); // Add a new index to the backlog
    }

    void UpdatePreview()
    {
        if (currentPreview != null) Destroy(currentPreview);

        int nextIndex = backlogIndexes.Peek(); // Get the next prefab index without removing it
        currentPreview = Instantiate(prefabs[nextIndex], Vector3.zero, Quaternion.identity); // Instantiate at 0,0 as preview
        currentPreview.GetComponent<Rigidbody2D>().simulated = false; // Stop physics simulation for the preview
        currentPreview.transform.localScale = previewScale; // Apply preview scale
    }

    Vector3 CalculateShootingDirection()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Ensure it's on the same plane
        return (mousePosition - Vector3.zero).normalized;
    }
}
