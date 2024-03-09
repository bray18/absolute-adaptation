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
        // Assuming a 16:9 aspect ratio
        float cameraHeight = mainCamera.orthographicSize * 2;
        float cameraWidth = cameraHeight * mainCamera.aspect;

        // Create Edge Colliders for the boundaries
        Vector2[] edgePoints;

        // Top boundary
        edgePoints = new Vector2[2] { new Vector2(-cameraWidth / 2, mainCamera.orthographicSize), new Vector2(cameraWidth / 2, mainCamera.orthographicSize) };
        AddEdgeCollider("Top Boundary", edgePoints);

        // Bottom boundary
        edgePoints = new Vector2[2] { new Vector2(-cameraWidth / 2, -mainCamera.orthographicSize), new Vector2(cameraWidth / 2, -mainCamera.orthographicSize) };
        AddEdgeCollider("Bottom Boundary", edgePoints);

        // Left boundary
        edgePoints = new Vector2[2] { new Vector2(-cameraWidth / 2, mainCamera.orthographicSize), new Vector2(-cameraWidth / 2, -mainCamera.orthographicSize) };
        AddEdgeCollider("Left Boundary", edgePoints);

        // Right boundary
        edgePoints = new Vector2[2] { new Vector2(cameraWidth / 2, mainCamera.orthographicSize), new Vector2(cameraWidth / 2, -mainCamera.orthographicSize) };
        AddEdgeCollider("Right Boundary", edgePoints);
    }

    void AddEdgeCollider(string name, Vector2[] points)
    {
        GameObject boundary = new GameObject(name);
        boundary.transform.parent = transform;
        EdgeCollider2D edgeCollider = boundary.AddComponent<EdgeCollider2D>();
        edgeCollider.points = points;
    }
}
