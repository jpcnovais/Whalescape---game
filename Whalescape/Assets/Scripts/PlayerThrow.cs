using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject bombPrefab;      // Prefab da bomba
    public Transform bombSpawnPoint;   // Ponto de spawn da bomba
    public float cooldownTime = 10f;   // Tempo de recarga
    public Image cooldownImage;        // Imagem do círculo de recarga

    private float nextFireTime = 0f;
    private bool isCoolingDown = false;

    public GameObject projectilePrefab; // Prefab do projétil
    public Transform launchPoint; // Ponto de lançamento do projétil
    public float launchForce; // Força inicial do lançamento
    public float angle; // Ângulo de lançamento em graus

    void Start()
    {
        // Configura o fillAmount para 1 no início para representar o cooldown completo
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
           // Instancia a bomba na posição do ponto de lançamento
        GameObject bomb = Instantiate(bombPrefab, launchPoint.position, launchPoint.rotation);

        // Obtém o Rigidbody da bomba
        Rigidbody rb = bomb.GetComponent<Rigidbody>();

        // Define a direção de lançamento apenas no eixo Z
        Vector3 launchDirection = Vector3.forward;

        // Converte a direção de lançamento para as coordenadas locais do jogador
        launchDirection = transform.TransformDirection(launchDirection);

        // Aplica a força à bomba na direção do eixo Z
        rb.AddForce(launchDirection * launchForce, ForceMode.Impulse);

        // Destrói a bomba após 3 segundos
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
