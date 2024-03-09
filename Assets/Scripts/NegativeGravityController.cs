using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegativeGravityController : MonoBehaviour
{
    public float gravityStrength = 10f; // Adjustable strength of the "edge gravity"
    public string exclusionTag = "NoEdgeGravity"; // Tag for objects to exclude

    void FixedUpdate()
    {
        Camera mainCamera = Camera.main; // Assuming the main camera is the one showing your game
        float cameraHeight = 2f * mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;

        Rigidbody2D[] allRigidbodies = FindObjectsOfType<Rigidbody2D>();

        foreach (Rigidbody2D rb in allRigidbodies)
        {
            // Skip objects with the exclusion tag
            if (!rb.isKinematic && rb.gameObject.tag != exclusionTag)
            {
                Vector3 directionToNearestEdge = CalculateDirectionToNearestEdge(rb.transform.position, cameraWidth, cameraHeight);
                rb.AddForce(directionToNearestEdge * gravityStrength, ForceMode2D.Force);
            }
        }
    }

    Vector3 CalculateDirectionToNearestEdge(Vector3 position, float cameraWidth, float cameraHeight)
    {
        // Convert position to local space relative to camera
        Vector3 localPosition = Camera.main.transform.InverseTransformPoint(position);

        // Calculate distances to each edge
        float distanceToLeftEdge = Mathf.Abs(localPosition.x + cameraWidth / 2);
        float distanceToRightEdge = Mathf.Abs(cameraWidth / 2 - localPosition.x);
        float distanceToBottomEdge = Mathf.Abs(localPosition.y + cameraHeight / 2);
        float distanceToTopEdge = Mathf.Abs(cameraHeight / 2 - localPosition.y);

        // Determine the closest edge
        float minDistance = Mathf.Min(distanceToLeftEdge, distanceToRightEdge, distanceToBottomEdge, distanceToTopEdge);

        // Calculate direction to the closest edge
        Vector3 directionToEdge = Vector3.zero;

        if (minDistance == distanceToLeftEdge) directionToEdge = Vector3.left;
        else if (minDistance == distanceToRightEdge) directionToEdge = Vector3.right;
        else if (minDistance == distanceToBottomEdge) directionToEdge = Vector3.down;
        else if (minDistance == distanceToTopEdge) directionToEdge = Vector3.up;

        return directionToEdge;
    }
}