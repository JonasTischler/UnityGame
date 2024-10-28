using UnityEngine;

public class Health : MonoBehaviour
{
    // Variável pública para ajustar a vida do NPC
    public float maxHealth = 100f;
    private float currentHealth;

    // Função para inicializar a vida do NPC
    void Start()
    {
        currentHealth = maxHealth; // Inicializa com o valor máximo de vida
    }

    // Função que lida com o recebimento de dano
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        // Se a vida atingir 0 ou menos, chama a função de morte
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Função que define o que acontece quando o NPC morre
    private void Die()
    {
        // Exemplo: Destruir o NPC, mas você pode adicionar mais lógica aqui
        Destroy(gameObject);
    }

    // Função para curar o NPC, se necessário
    public void Heal(float healAmount)
    {
        currentHealth += healAmount;

        // Garante que a vida não ultrapasse o máximo
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
