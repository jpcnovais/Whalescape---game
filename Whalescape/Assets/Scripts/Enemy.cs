using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Transform checkpoint1;

    [SerializeField]
    private Transform checkpoint2;

    [SerializeField]
    private float speed;

    [SerializeField]
    private bool isMovingLeft;

    private float tolerance = 0.1f; // Tolerância para evitar tremores

    void Start()
    {
        if (checkpoint1.position.x > checkpoint2.position.x)
        {
            var aux = checkpoint2;
            checkpoint2 = checkpoint1;
            checkpoint1 = aux;
        }
    }

    void Update()
    {
        // Depuração para verificar a posição do inimigo
        Debug.Log("Update - Posição do inimigo: " + transform.position);
    }

    void FixedUpdate()
    {
        if (isMovingLeft)
        {
            if (transform.position.x <= checkpoint1.position.x + tolerance)
            {
                isMovingLeft = !isMovingLeft;
                Debug.Log("Chegou ao checkpoint1, mudando direção para a direita");
            }
        }
        else
        {
            if (transform.position.x >= checkpoint2.position.x - tolerance)
            {
                isMovingLeft = !isMovingLeft;
                Debug.Log("Chegou ao checkpoint2, mudando direção para a esquerda");
            }
        }
        int direction = isMovingLeft ? -1 : 1;
        transform.position += new Vector3(direction * speed * Time.deltaTime, 0, 0);

        // Log para verificar direção e posição
        Debug.Log("FixedUpdate - Posição do inimigo: " + transform.position + ", direção: " + (isMovingLeft ? "esquerda" : "direita"));
    }
}
