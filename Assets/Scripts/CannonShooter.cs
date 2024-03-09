using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShooter : MonoBehaviour
{
    public GameObject[] prefabs; // Assign this in the Inspector with your prefabs
    public float shootForce = 1000f; // Adjust based on your needs

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            ShootPrefab();
        }
    }

    void ShootPrefab()
    {
        GameObject prefabToShoot = SelectPrefab();
        if (prefabToShoot != null)
        {
            Vector3 shootingDirection = CalculateShootingDirection();
            GameObject projectile = Instantiate(prefabToShoot, transform.position, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().AddForce(shootingDirection * shootForce);
        }
    }

    GameObject SelectPrefab()
    {
        // Simple weighted selection towards lower numbers
        // This assumes your prefabs are sorted from 1-7 in the array
        int[] weights = {7, 6, 5, 4, 3, 2, 1}; // Inverse weighting
        int totalWeight = 0;
        foreach (int weight in weights) totalWeight += weight;
        
        int randomWeight = Random.Range(1, totalWeight + 1);
        int selectedIndex = 0;

        foreach (int weight in weights)
        {
            if (randomWeight <= weight)
            {
                break;
            }
            randomWeight -= weight;
            selectedIndex++;
        }

        // Ensure selectedIndex is within bounds of prefabs array
        selectedIndex = Mathf.Min(selectedIndex, prefabs.Length - 1);
        return prefabs[selectedIndex];
    }

    Vector3 CalculateShootingDirection()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // For 2D
        Vector3 direction = (mousePosition - transform.position).normalized;
        return direction;
    }
}

