using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public float delayBeforeAffected = 1.0f; // Time in seconds before gravity affects the projectile
    private bool isAffectedByGravity = false; // Initial state

    void Start()
    {
        // Start the countdown to being affected by gravity
        CombinationTracker.Instance.ResetCombinations();
        StartCoroutine(BecomeAffectedByGravityAfterDelay());
    }

    IEnumerator BecomeAffectedByGravityAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeAffected);
        isAffectedByGravity = true;
        gameObject.tag = "AffectedByGravity"; // Change the tag to make it affected by edge gravity
    }

    public bool IsAffectedByGravity()
    {
        return isAffectedByGravity;
    }
}