using UnityEngine;

public class ZombieChase : MonoBehaviour
{
    public float speed = 5f; // Velocidade do lobo
    public float chaseRadius = 10f; // Raio de detecção do jogador
    public Transform player; // Referência ao jogador
    private Rigidbody2D rb; // Referência ao Rigidbody2D
    private bool isFacingRight = false; // Indica se o lobo está virado para a direita (iniciado para a esquerda)
    private PatrolWithRandomTimer patrolScript; // Referência ao script de patrulha

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        patrolScript = GetComponent<PatrolWithRandomTimer>(); // Pega a referência do script de patrulha
    }

    void Update()
    {
        // Verifica a distância do jogador
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Se o jogador estiver dentro do raio de chase
        if (distanceToPlayer < chaseRadius)
        {
            patrolScript.canPatrol = false; // Desativa a patrulha
            ChasePlayer();
        }
        else
        {
            patrolScript.canPatrol = true; // Ativa a patrulha quando o jogador estiver fora do raio
        }
    }

    void ChasePlayer()
    {
        // Move o lobo em direção ao jogador apenas no eixo X
        Vector2 direction = (player.position - transform.position).normalized;

        // Definindo a direção no eixo Y como zero, para evitar que o lobo suba
        direction.y = 0;

        // Atualiza a posição do lobo usando MovePosition, apenas no eixo X
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);

        // Vira o lobo para olhar na direção do jogador
        if (direction.x > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (direction.x < 0 && isFacingRight)
        {
            Flip();
        }
    }


    private void Flip()
    {
        // Inverte a direção
        isFacingRight = !isFacingRight;

        // Altera a escala do objeto para virar
        Vector3 theScale = transform.localScale;
        theScale.x *= -1; // Inverte a escala X
        transform.localScale = theScale; // Aplica a nova escala
    }
}