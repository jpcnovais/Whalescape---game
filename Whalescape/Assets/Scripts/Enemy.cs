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
        // Depuração
        Debug.Log("Update - posição do inimigo: " + transform.position);
    }

    void FixedUpdate()
    {
        if (isMovingLeft)
        {
            if (transform.position.x < checkpoint1.position.x)
            {
                isMovingLeft = !isMovingLeft;
                Debug.Log("Chegou ao checkpoint1, mudando direção para a direita");
            }
        }
        else
        {
            if (transform.position.x > checkpoint2.position.x)
            {
                isMovingLeft = !isMovingLeft;
                Debug.Log("Chegou ao checkpoint2, mudando direção para a esquerda");
            }
        }
        int direction = isMovingLeft ? -1 : 1;
        transform.position += new Vector3(direction * speed * Time.deltaTime, 0, 0);
        GetComponent<SpriteRenderer>().flipX = !isMovingLeft;

        // Depuração
        Debug.Log("FixedUpdate - posição do inimigo: " + transform.position);
        Debug.Log("FixedUpdate - direção: " + (isMovingLeft ? "esquerda" : "direita"));
    }
}
