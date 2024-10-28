using UnityEngine;

public class WolfChase : MonoBehaviour
{
    public float speed = 5f; // Velocidade do lobo
    public float chaseRadius = 10f; // Raio de detec��o do jogador
    public Transform player; // Refer�ncia ao jogador
    private Rigidbody2D rb; // Refer�ncia ao Rigidbody2D
    private bool isFacingRight = false; // Indica se o lobo est� virado para a direita (iniciado para a esquerda)
    private PatrolWithRandomTimer patrolScript; // Refer�ncia ao script de patrulha

    // Novas vari�veis para controle do chase
    public float maxChaseDuration = 5f; // Dura��o m�xima da persegui��o em segundos
    private float chaseTimer; // Timer para controlar a dura��o da persegui��o
    private bool isChasing; // Indica se o lobo est� em modo de persegui��o

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        patrolScript = GetComponent<PatrolWithRandomTimer>(); // Pega a refer�ncia do script de patrulha
        chaseTimer = 0f; // Inicializa o timer de chase
    }

    void Update()
    {
        // Verifica a dist�ncia do jogador
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Se o jogador estiver dentro do raio de chase
        if (distanceToPlayer < chaseRadius)
        {
            // Inicia ou reinicia o chase
            isChasing = true;
            chaseTimer = maxChaseDuration; // Reinicia o timer de chase
            patrolScript.canPatrol = false; // Desativa a patrulha
            ChasePlayer();
        }
        else if (isChasing)
        {
            // Se o lobo estava em chase e o jogador se afastou
            if (chaseTimer > 0)
            {
                chaseTimer -= Time.deltaTime; // Decrementa o timer
                ChasePlayer(); // Continua perseguindo
            }
            else
            {
                isChasing = false; // Desativa o chase
                patrolScript.canPatrol = true; // Ativa a patrulha
            }
        }
        else
        {
            patrolScript.canPatrol = true; // Ativa a patrulha quando o jogador estiver fora do raio
        }
    }

    void ChasePlayer()
    {
        // Move o lobo em dire��o ao jogador apenas no eixo X
        Vector2 direction = (player.position - transform.position).normalized;

        // Definindo a dire��o no eixo Y como zero, para evitar que o lobo suba
        direction.y = 0;

        // Atualiza a posi��o do lobo usando MovePosition, apenas no eixo X
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);

        // Vira o lobo para olhar na dire��o do jogador
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
        // Inverte a dire��o
        isFacingRight = !isFacingRight;

        // Altera a escala do objeto para virar
        Vector3 theScale = transform.localScale;
        theScale.x *= -1; // Inverte a escala X
        transform.localScale = theScale; // Aplica a nova escala
    }
}
