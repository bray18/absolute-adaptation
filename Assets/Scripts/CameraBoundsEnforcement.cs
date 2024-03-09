using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundsEnforcer : MonoBehaviour
{
    public Camera mainCamera;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    void Start()
    {
        // Calculate the screen bounds in world coordinates
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; // Half the width of the object
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; // Half the height of the object

        CreateBoundaries();
    }

    void CreateBoundaries()
    {
        // Adjust these positions and sizes as necessary to fit your game's needs
        AddBoundary("Top Boundary", new Vector2(0, screenBounds.y + objectHeight), new Vector2(screenBounds.x * 2, 0.1f));
        AddBoundary("Bottom Boundary", new Vector2(0, -screenBounds.y - objectHeight), new Vector2(screenBounds.x * 2, 0.1f));
        AddBoundary("Left Boundary", new Vector2(-screenBounds.x - objectWidth, 0), new Vector2(0.1f, screenBounds.y * 2));
        AddBoundary("Right Boundary", new Vector2(screenBounds.x + objectWidth, 0), new Vector2(0.1f, screenBounds.y * 2));
    }

    void AddBoundary(string name, Vector2 position, Vector2 size)
    {
        GameObject boundary = new GameObject(name);
        boundary.transform.position = position;
        BoxCollider2D collider = boundary.AddComponent<BoxCollider2D>();
        collider.size = size;
        boundary.transform.parent = transform; // Optionally set as a child of a specific GameObject
    }
}
