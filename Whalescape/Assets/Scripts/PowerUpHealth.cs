using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;

public class PowerUpHealth : MonoBehaviour
{
    [SerializeField]
    public float Health = 1.2f;

    void OnTrggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PickUp(other);
        }
    }

    void PickUp(Collider player)
    {
        Debug.Log("Colisão entre o personagem e o powerup");
        /*
        PlayerController_LIFE stats = player.GetComponent<PlayerController_LIFE>();
        stats.health *= Health;
        */
        //nome do codigo do personagem

        Destroy(gameObject);
    }
}
