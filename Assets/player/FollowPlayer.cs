using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public float xOffset;
    public float yOffset;
    public float smoothing;

    private void LateUpdate()
    {
        if (player != null)
        {
            // Get the player's current position
            Vector3 playerPosition = player.transform.position;

            // Offset the player's position on both X and Y axes
            playerPosition.x += xOffset;
            playerPosition.y += yOffset;

            // Keep the camera's Z position constant
            playerPosition.z = transform.position.z;

            // Use Lerp for smooth camera movement
            transform.position = Vector3.Lerp(transform.position, playerPosition, smoothing * Time.deltaTime);
        }
    }
}