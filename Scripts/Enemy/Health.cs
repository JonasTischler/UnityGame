using UnityEngine;

public class Health : MonoBehaviour
{
    // Vari�vel p�blica para ajustar a vida do NPC
    public float maxHealth = 100f;
    private float currentHealth;

    // Fun��o para inicializar a vida do NPC
    void Start()
    {
        currentHealth = maxHealth; // Inicializa com o valor m�ximo de vida
    }

    // Fun��o que lida com o recebimento de dano
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        // Se a vida atingir 0 ou menos, chama a fun��o de morte
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Fun��o que define o que acontece quando o NPC morre
    private void Die()
    {
        // Exemplo: Destruir o NPC, mas voc� pode adicionar mais l�gica aqui
        Destroy(gameObject);
    }

    // Fun��o para curar o NPC, se necess�rio
    public void Heal(float healAmount)
    {
        currentHealth += healAmount;

        // Garante que a vida n�o ultrapasse o m�ximo
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
