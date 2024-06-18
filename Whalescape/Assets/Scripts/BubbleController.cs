using UnityEngine;
using System.Linq;

public class BubbleController : MonoBehaviour
{
    public Transform player;
    public GameObject fireballPrefab;
    public Transform launchPoint;
    public float launchForce = 10f;
    public float shootInterval = 2f;

    private float shootTimer;

    void Start()
    {
        shootTimer = shootInterval;
    }

    void Update()
    {
        LookAtPlayer();
        shootTimer -= Time.deltaTime;

        if (shootTimer <= 0)
        {
            ShootFireballs();
            shootTimer = shootInterval;
        }
    }

    void LookAtPlayer()
    {
        Vector3 originalPosition = transform.position;
        transform.LookAt(player);
        transform.position = originalPosition;
    }

    void ShootFireballs()
    {
        float[] angles = { -40f, -20f, 0f, 20f, 40f };
        angles = angles.OrderBy(x => Random.value).ToArray();
        float[] selectedAngles = angles.Take(3).ToArray();

        foreach (float angle in selectedAngles)
        {
            GameObject fireball = Instantiate(fireballPrefab, launchPoint.position, launchPoint.rotation);
            Rigidbody rb = fireball.GetComponent<Rigidbody>();
            Vector3 direction = Quaternion.Euler(0, angle, 0) * transform.forward;
            rb.AddForce(direction * launchForce, ForceMode.Impulse);

            // Destruir a bola de fogo após 3 segundos
            Destroy(fireball, 3f);
        }
    }

    
}
