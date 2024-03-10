using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverZone : MonoBehaviour
{
    public float radius = 20f; // The radius within which to check for objects
    public float timeToGameOver = 0.5f; // Time in seconds an object must stay within the radius to trigger game over
    private Dictionary<GameObject, float> objectsInZone = new Dictionary<GameObject, float>();

    void Update()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(Vector2.zero, radius);
        //Debug.Log("Objects detected: " + objects.Length); // Debug how many objects are detected

        foreach (Collider2D obj in objects)
        {
            if (IsTargetObject(obj.gameObject))
            {
                //Debug.Log("Target object detected: " + obj.gameObject.name); // Confirm detection of target objects

                if (!objectsInZone.ContainsKey(obj.gameObject))
                {
                    objectsInZone[obj.gameObject] = Time.time;
                }
                else if (Time.time - objectsInZone[obj.gameObject] > timeToGameOver)
                {
                    //Debug.Log("Game Over triggered by: " + obj.gameObject.name); // Confirm game over trigger
                    SceneManager.LoadScene("GameOver");
                }
            }
        }

        // Remove objects that have moved out of the zone
        List<GameObject> toRemove = new List<GameObject>();
        foreach (var obj in objectsInZone)
        {
            if (!obj.Key || (obj.Key.transform.position - Vector3.zero).magnitude > radius)
            {
                toRemove.Add(obj.Key);
            }
        }
        foreach (var obj in toRemove)
        {
            objectsInZone.Remove(obj);
        }

    }

    private bool IsTargetObject(GameObject obj)
    {
        // Check if the object's tag is one of the specified types
        switch (obj.tag)
        {
            case "Type1":
            case "Type2":
            case "Type3":
            case "Type4":
            case "Type5":
            case "Type6":
            case "Type7":
                return true;
            default:
                return false;
        }
    }
}