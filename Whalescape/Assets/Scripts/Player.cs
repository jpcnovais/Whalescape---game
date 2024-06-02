using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private string nextscene;
    private Rigidbody playerRb;
    [SerializeField]
    private float movementSpeed;
    private float horizontal;

    [SerializeField]
    private float jumpPower;
    private bool grounded;
    private bool canDoubleJump;

    int vidas = 3;

    [SerializeField]
    private List<Image> images = new List<Image>();

    private Transform spawnPoint;


    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        GameObject spawnPointObject = GameObject.FindWithTag("SpawnPoint");

        if (spawnPointObject != null)
        {
            spawnPoint = spawnPointObject.transform;

            transform.position = spawnPoint.position;
        }
        else
        {
            Debug.LogWarning("Spawn point não encontrado na cena.");
        }
    }

    void Update()
    {
        horizontal = -Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            if (grounded)
            {
                playerRb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
                canDoubleJump = true;
                grounded = false;
            }
            else if (canDoubleJump)
            {
                canDoubleJump = false;
                playerRb.velocity = new Vector3(playerRb.velocity.x, 0, playerRb.velocity.z);
                playerRb.AddForce(Vector3.up * (jumpPower / 1.75f), ForceMode.Impulse);
            }
        }
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        playerRb.velocity = new Vector3(playerRb.velocity.x, playerRb.velocity.y, horizontal * movementSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            grounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            grounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "plataforma")
        {
            grounded = true;
            canDoubleJump = false;

        }

        if (collision.gameObject.tag == "LimiteEcra")
        {
            Debug.Log("Colisão com o bordo do ecrã");

            if (vidas > 0)
            {
                if (vidas <= images.Count)
                {
                    Debug.Log("Desativando imagem " + vidas);
                    images[vidas - 1].gameObject.SetActive(false);

                }

                vidas--;
                if (vidas == 0)
                {
                    if (SceneManager.GetActiveScene().name == "nivel1")
                    {
                        SceneManager.LoadScene("gameover1");
                    }
                    else if (SceneManager.GetActiveScene().name == "nivel2")
                    {
                        SceneManager.LoadScene("gameover2");
                    }
                }
            }
        }

        if (collision.gameObject.tag == "Inimigos")
        {
            Debug.Log("Colisão com inimigo");

            if (vidas > 0)
            {
                Vector3 PlatPosition = spawnPoint.position;
                PlatPosition.x += 0.5f;
                this.gameObject.transform.position = PlatPosition;

                if (vidas <= images.Count)
                {
                    Debug.Log("Desativando imagem " + vidas);
                    images[vidas - 1].gameObject.SetActive(false);
                }
                vidas--;

                if (vidas == 0)
                {
                    if (SceneManager.GetActiveScene().name == "cenario1")
                    {
                        SceneManager.LoadScene("gameover1");
                    }
                    else if (SceneManager.GetActiveScene().name == "cenario2")
                    {
                        SceneManager.LoadScene("gameover2");
                    }
                }
            }
        }

        else if (collision.gameObject.tag == "elevador")
        {
            SceneManager.LoadScene(nextscene);
        }
    }
}
