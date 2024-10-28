using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;         // Prefab da bala para a direita
    public GameObject bulletEsquerdaPrefab; // Prefab da bala para a esquerda
    public Transform firePoint;             // Ponto de origem do disparo
    public float fireRate = 0.5f;           // Tempo entre tiros (em segundos)
    public float reloadTime = 2f;           // Tempo de recarga (em segundos)
    public int maxAmmo = 10;                // Tamanho do pente
    public int currentAmmo;                  // Balas restantes no pente
    private float reloadCooldown = 0f;      // Tempo de cooldown para recarregar

    private bool isFacingRight = true;      // Controla a direção do jogador
    private float nextTimeToFire = 0f;      // Controla quando o jogador pode atirar novamente
    private bool isReloading = false;        // Controla se está recarregando

    void Start()
    {
        currentAmmo = maxAmmo; // Inicializa as balas restantes com o tamanho do pente
    }

    void Update()
    {
        // Verifica se o jogador está tentando atirar e se o cooldown terminou
        if (Input.GetKeyDown(KeyCode.F) && Time.time >= nextTimeToFire && !isReloading)
        {
            if (currentAmmo > 0) // Verifica se ainda há balas
            {
                // Define o tempo para o próximo tiro
                nextTimeToFire = Time.time + fireRate;

                // Chama a função de disparo
                Shoot();
            }
            else
            {
                StartReload(); // Inicia a recarga se não houver balas
            }
        }

        // Verifica se o jogador pressionou a tecla para recarregar
        if (Input.GetKeyDown(KeyCode.R) && !isReloading && currentAmmo < maxAmmo)
        {
            StartReload();
        }

        // Lógica de recarga
        if (isReloading)
        {
            reloadCooldown -= Time.deltaTime; // Reduz o cooldown da recarga
            if (reloadCooldown <= 0)
            {
                currentAmmo = maxAmmo; // Recarrega o pente
                isReloading = false;
                Debug.Log("Recarregado!");
            }
        }
    }

    void Shoot()
    {
        if (bulletPrefab == null || bulletEsquerdaPrefab == null)
        {
            Debug.LogWarning("Prefabs de bala não estão definidos!");
            return;
        }

        // Verifica a direção em que o jogador está virado
        GameObject bullet;
        if (isFacingRight)
        {
            // Dispara para a direita
            bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        }
        else
        {
            // Dispara para a esquerda
            bullet = Instantiate(bulletEsquerdaPrefab, firePoint.position, Quaternion.identity);
        }

        // Aplica a velocidade na direção correta, dependendo da face do jogador
        bullet.GetComponent<Bullet>().Vel *= transform.localScale.x; // Multiplica pela escala local do jogador

        currentAmmo--; // Reduz a quantidade de balas restantes
    }

    // Função para atualizar a direção do jogador
    public void UpdateFacingDirection(bool facingRight)
    {
        isFacingRight = facingRight;
    }

    // Inicia o processo de recarregamento
    private void StartReload()
    {
        isReloading = true;
        reloadCooldown = reloadTime; // Define o cooldown de recarga
        Debug.Log("Recarregando...");
    }
}
