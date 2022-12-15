using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Coded by Mark Beveridge - CGDP Year 1
/// </summary>

public class CameraMovement : MonoBehaviour
{
   

    //declares object to be used as a target - can be set in unity editor
    [SerializeField] private Transform player;
    //sets the delay in movement
    [SerializeField] private float dampTime = 0.4f;
    [SerializeField] private Vector3 offset;
    //declares position variables to be altered for the camera
    private Vector3 cameraPos;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    private Vector3 position;

    void Update()
    {
        // sets the target location for the camera to move to
        cameraPos = new Vector3(player.position.x, player.position.y, -10f);
        //subtracts the desired offset
        cameraPos -= offset;
        // moves the camera if its not at the desired location, but with a delay
        transform.position = Vector3.SmoothDamp(gameObject.transform.position, cameraPos, ref velocity, dampTime);
         position = transform.position;
        Clamp(ref position);
        transform.position = position;
        
    }

    public Vector3 Clamp(ref Vector3 value)
    {
        value.x = Mathf.Clamp(value.x, minX, maxX);
        value.y = Mathf.Clamp(value.y, minY, maxY);
        return value;
    }
}
