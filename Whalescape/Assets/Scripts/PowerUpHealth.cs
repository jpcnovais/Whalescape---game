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


        Destroy(gameObject);
    }
}
