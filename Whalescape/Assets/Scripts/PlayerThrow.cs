using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject bombPrefab;
    public float cooldownTime = 10f;
    public Image cooldownImage;

    private float nextFireTime = 0f;
    private bool isCoolingDown = false;


    public Transform launchPoint;
    public float launchForce;
    public float angle;

    void Start()
    {

        cooldownImage.fillAmount = 1f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && CanFire())
        {
            FireBomb();
            StartCooldown();
            isCoolingDown = true;
        }

        if (isCoolingDown)
        {
            UpdateCooldownUI();
        }
    }

    void FireBomb()
    {
        {

            GameObject bomb = Instantiate(bombPrefab, launchPoint.position, launchPoint.rotation);

            Rigidbody rb = bomb.GetComponent<Rigidbody>();


            Vector3 launchDirection = Vector3.forward;

            launchDirection = transform.TransformDirection(launchDirection);

            rb.AddForce(launchDirection * launchForce, ForceMode.Impulse);

            Destroy(bomb, 3f);
        }
    }

    bool CanFire()
    {
        return Time.time >= nextFireTime;
    }

    void StartCooldown()
    {
        nextFireTime = Time.time + cooldownTime;
    }

    void UpdateCooldownUI()
    {
        float cooldownRemaining = nextFireTime - Time.time;
        float fillAmount = Mathf.Clamp01(1 - (cooldownRemaining / cooldownTime));

        cooldownImage.fillAmount = fillAmount;

        if (cooldownRemaining <= 0)
        {
            isCoolingDown = false;
        }
    }
}
