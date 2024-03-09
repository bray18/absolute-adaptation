using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundsEnforcer : MonoBehaviour
{
    public Camera mainCamera;

    void Start()
    {
        CreateBoundaries();
    }

    void CreateBoundaries()
    {
        float screenAspect = 16f / 9f;
        float cameraHeight = mainCamera.orthographicSize * 2;
        float cameraWidth = cameraHeight * screenAspect;
        
        // Top Boundary
        AddBoundary("Top Boundary", new Vector2(0, mainCamera.orthographicSize), new Vector2(cameraWidth, 0.1f));
        // Bottom Boundary
        AddBoundary("Bottom Boundary", new Vector2(0, -mainCamera.orthographicSize), new Vector2(cameraWidth, 0.1f));
        // Left Boundary
        AddBoundary("Left Boundary", new Vector2(-cameraWidth / 2, 0), new Vector2(0.1f, cameraHeight));
        // Right Boundary
        AddBoundary("Right Boundary", new Vector2(cameraWidth / 2, 0), new Vector2(0.1f, cameraHeight));
    }

    void AddBoundary(string name, Vector2 position, Vector2 size)
    {
        GameObject boundary = new GameObject(name);
        // Position adjustment since the camera is centered, we offset by half size accordingly for left and right
        float adjustedPositionX = position.x + (size.x == 0.1f ? (position.x > 0 ? -size.y / 2 : size.y / 2) : 0);
        float adjustedPositionY = position.y + (size.y == 0.1f ? (position.y > 0 ? -size.x / 2 : size.x / 2) : 0);
        boundary.transform.position = new Vector2(adjustedPositionX, adjustedPositionY);
        boundary.transform.localScale = new Vector3(size.x, size.y, 1);
        BoxCollider2D collider = boundary.AddComponent<BoxCollider2D>();
        collider.size = new Vector2(1, 1); // Collider size set to 1,1 because we're scaling the GameObject
        collider.isTrigger = false; // Make sure it's not a trigger
        boundary.transform.parent = this.transform; // Optionally set as a child of the camera to move with it
    }
}
