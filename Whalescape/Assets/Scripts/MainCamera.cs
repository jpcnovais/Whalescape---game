using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraPrincipal : MonoBehaviour
{
    private Transform player;
    private Vector3 offset;

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
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, player.position.z + offset.z);

            
        }
    }
}
