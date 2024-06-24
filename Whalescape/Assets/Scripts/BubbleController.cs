using UnityEngine;
using System.Linq;

public class BubbleController : MonoBehaviour
{
    public Transform player;
    public GameObject fireballPrefab;
    public Transform launchPoint;
    public float launchForce = 10f;
    public float shootInterval = 2f;
    public float detectionRange = 30f;

    private float shootTimer;

    void Start()
    {
        shootTimer = shootInterval;
    }

    void Update()
    {
        LookAtPlayer();
        shootTimer -= Time.deltaTime;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= detectionRange && shootTimer <= 0)
        {
            ShootFireballs();
            shootTimer = shootInterval;
        }
    }

    void LookAtPlayer()
    {
        Vector3 targetDirection = player.position - transform.position;

        targetDirection.y = 0;

        float singleStep = 2 * Time.deltaTime;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        Debug.DrawRay(transform.position, newDirection, Color.red);

        transform.rotation = Quaternion.LookRotation(newDirection);
    }

    void ShootFireballs()
    {
        float[] angles = { -40f, -20f, 0f, 20f, 40f };
        angles = angles.OrderBy(x => Random.value).ToArray();

        int fireballCount = 1;


        float randomValue = Random.value;
        if (randomValue < 0.2f)
        {
            fireballCount = 3;
        }
        else if (randomValue < 0.4f)
        {
            fireballCount = 2;
        }

        float[] selectedAngles = angles.Take(fireballCount).ToArray();

        foreach (float angle in selectedAngles)
        {
            GameObject fireball = Instantiate(fireballPrefab, launchPoint.position, launchPoint.rotation);
            Rigidbody rb = fireball.GetComponent<Rigidbody>();
            Vector3 direction = Quaternion.Euler(0, angle, 0) * transform.forward;
            rb.AddForce(direction * launchForce, ForceMode.Impulse);

            Destroy(fireball, 3f);
        }
    }
}
