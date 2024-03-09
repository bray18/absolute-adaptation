using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAim : MonoBehaviour
{
    //this sscript is attached to the ball prefab to shoot the ball.
    //It is controlled by the user's mouse input, where the user points to a location and clicks to shoot the ball in that direction.
    //Peggle-style.
    //swag

    public float speed = 10.0f;
    public Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //track mouse position
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        //calculate angle
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        //shoot ball from different file
        if (Input.GetMouseButtonDown(0))
        {
            //shoot the ball
        }
    }
}
