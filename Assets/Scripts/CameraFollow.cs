using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // Reference to the player's transform
    public float smoothSpeed = 0.125f;  // Smooth speed for camera movement
    public Vector3 offset;  // Offset from the player

    void LateUpdate()
    {
        if (player == null)
            return;

        // Target position is the player's position + the offset
        Vector3 targetPosition = player.position + offset;

        // Smoothly move towards the target position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);

        // Update the camera's position
        transform.position = smoothedPosition;
    }
}
