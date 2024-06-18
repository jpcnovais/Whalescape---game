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
       // Determine which direction to rotate towards
        Vector3 targetDirection = player.position - transform.position;

        targetDirection.y = 0;

        // The step size is equal to speed times frame time.
        float singleStep = 2 * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        // Draw a ray pointing at our target in
        Debug.DrawRay(transform.position, newDirection, Color.red);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
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
