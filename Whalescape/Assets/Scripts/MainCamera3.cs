using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraPrincipal3 : MonoBehaviour
{
    private Transform player;
    private Vector3 offset;


    private float maxZ = 6.86f;

    private float minX = -15f;

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

            Vector3 newPosition = new Vector3(player.position.x + offset.x, player.position.y + offset.y, player.position.z + offset.z);

            newPosition.z = Mathf.Min(newPosition.z, maxZ);

            newPosition.x = Mathf.Max(newPosition.x, minX);


            transform.position = newPosition;
        }
    }
}
