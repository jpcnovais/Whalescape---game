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
        // Instanciar a bomba no ponto de spawn com a rotação atual do ponto de spawn
        GameObject bomb = Instantiate(bombPrefab, bombSpawnPoint.position, bombSpawnPoint.rotation);

        // Aplicar força à bomba para que ela se mova na direção em que o jogador está olhando
        Rigidbody bombRigidbody = bomb.GetComponent<Rigidbody>();
        if (bombRigidbody != null)
        {
            // Ajuste a força e velocidade de acordo com as necessidades do seu jogo
            bombRigidbody.AddForce(bombSpawnPoint.forward * 500f, ForceMode.Impulse);
            bombRigidbody.velocity = bombSpawnPoint.forward * 10f;
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
