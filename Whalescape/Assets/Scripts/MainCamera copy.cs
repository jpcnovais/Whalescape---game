using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraPrincipal2 : MonoBehaviour
{
    private Transform player;
    private Vector3 offset;

    // Maximum Z position the camera can reach
    private float maxZ = 6.86f;
    // Minimum X position the camera can reach
    private float minX = -15f;  // Adjust this value as needed

    void Start()
    {
        GameObject playerObject = GameObject.Find("player");
        if (playerObject != null)
        {
            player = playerObject.GetComponent<Transform>();
            Debug.Log("Player found.");
        }
        else
        {
            Debug.LogError("GameObject 'player' not found in the scene.");
        }

        offset = new Vector3(-5f, 1f, 0f);
    }

    void LateUpdate()
    {
        if (player != null)
        {
            // Calculate the new position
            Vector3 newPosition = new Vector3(player.position.x + offset.x, player.position.y + offset.y, player.position.z + offset.z);
            
            // Clamp the Z position to not exceed maxZ
            newPosition.z = Mathf.Min(newPosition.z, maxZ);
            
            // Clamp the X position to not go below minX
            newPosition.x = Mathf.Max(newPosition.x, minX);

            // Set the camera position
            transform.position = newPosition;
        }
    }
}
