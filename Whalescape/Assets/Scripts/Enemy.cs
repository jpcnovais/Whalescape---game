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
        if (checkpoint1.position.z > checkpoint2.position.z)
        {
            var aux = checkpoint2;
            checkpoint2 = checkpoint1;
            checkpoint1 = aux;
        }
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        if (isMovingLeft)
        {
            if (transform.position.z < checkpoint1.position.z)
            {
                isMovingLeft = !isMovingLeft;
            }
        }
        else
        {
            if (transform.position.z > checkpoint2.position.z)
            {
                isMovingLeft = !isMovingLeft;
            }
        }

        int direction = isMovingLeft ? -1 : 1;
        transform.position += new Vector3(0, 0, direction * speed * Time.deltaTime);

        transform.rotation = Quaternion.Euler(0, isMovingLeft ? 180 : 0, 0);
    }
}
