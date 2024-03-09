using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class CannonShooter : MonoBehaviour
{
    public GameObject[] prefabs; // Assign this in the Inspector with your prefabs
    public float shootForce = 1000f; // Adjust based on your needs

    private Queue<GameObject> backlog = new Queue<GameObject>(); // Backlog of prefabs
    private GameObject currentDisplay; // Currently displayed prefab as preview
    public int backlogSize = 5; // Size of the backlog

    private void Start()
    {
        FillBacklog();
        UpdateDisplay();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            ShootPrefab();
            UpdateBacklog();
            UpdateDisplay();
        }
    }

    void ShootPrefab()
    {
        if (currentDisplay != null)
        {
            // This time, simply enable physics and apply force to the current display, then nullify it
            Vector3 shootingDirection = CalculateShootingDirection();
            currentDisplay.GetComponent<Rigidbody2D>().simulated = true; // Enable physics simulation for shooting
            currentDisplay.GetComponent<Rigidbody2D>().AddForce(shootingDirection * shootForce);
            currentDisplay = null; // Ensure we don't try to interact with this object further
        }
    }

    void FillBacklog()
    {
        for (int i = 0; i < backlogSize; i++)
        {
            backlog.Enqueue(SelectPrefab());
        }
    }

    void UpdateBacklog()
    {
        // Instantiate a new object for the next shot, and enqueue it
        if (currentDisplay != null) Destroy(currentDisplay); // Destroy the old display if it exists
        backlog.Dequeue(); // Remove the first element, which was just shot
        backlog.Enqueue(SelectPrefab()); // Add a new prefab to the backlog
    }

    void UpdateDisplay()
    {
        GameObject nextPrefab = backlog.Peek(); // Get the next prefab to show without removing it
        currentDisplay = Instantiate(nextPrefab, Vector3.zero, Quaternion.identity); // Instantiate at 0,0 as preview
        currentDisplay.GetComponent<Rigidbody2D>().simulated = false; // Stop physics simulation for the preview
        // Do not adjust the scale here; let it remain as defined by the prefab
    }

    GameObject SelectPrefab()
    {
        // Simplified selection logic for demonstration; replace with your method as needed
        return prefabs[Random.Range(0, prefabs.Length)];
    }

    Vector3 CalculateShootingDirection()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // For 2D
        Vector3 direction = (mousePosition - Vector3.zero).normalized;
        return direction;
    }
}