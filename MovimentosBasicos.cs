using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidade de movimento
    public float jumpForce = 10f; // Força do pulo
    public LayerMask groundLayer; // Camada do chão
    public Transform groundCheck; // Transform para verificar se está no chão
    public float groundCheckRadius = 0.2f; // Raio para verificar se está no chão

    private Rigidbody2D rb;
    private Animator animator; // Adição para controlar animações
    private bool isGrounded;
    private bool isFacingRight = true; // Para verificar a direção do personagem
    private float jumpCooldown = 0.8f; // Tempo de cooldown para pular
    private float lastJumpTime; // Tempo em que o personagem pulou pela última vez

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obter o componente Rigidbody2D
        animator = GetComponent<Animator>(); // Obter o componente Animator
    }

    private void Update()
    {
        // Verifica se está no chão
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Movimento horizontal
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Lógica de pulo com cooldown
        if (Input.GetButtonDown("Jump")) // Se o botão de pulo foi pressionado
        {
            // Verifica se está no chão e se o cooldown de pulo já passou
            if (isGrounded && Time.time >= lastJumpTime + jumpCooldown)
            {
                Jump(); // Realiza o pulo
                lastJumpTime = Time.time; // Atualiza o tempo do último pulo
            }
            else // Caso contrário, não pode pular
            {
                Debug.Log("Você não pode pular no ar!"); // Mensagem de debug
            }
        }

        // Lógica de animação
        if (moveInput != 0) // Se o jogador está se movendo
        {
            if (moveInput > 0) // Movimento para a direita
            {
                if (!isFacingRight)
                {
                    Flip(); // Vira para a direita
                }
                animator.SetBool("isRunning", true);
                animator.SetBool("isIdleRight", false); // Desativa idle direito
                animator.SetBool("isIdleLeft", false);  // Desativa idle esquerdo
            }
            else if (moveInput < 0) // Movimento para a esquerda
            {
                if (isFacingRight)
                {
                    Flip(); // Vira para a esquerda
                }
                animator.SetBool("isRunning", true);
                animator.SetBool("isIdleRight", false); // Desativa idle direito
                animator.SetBool("isIdleLeft", false);  // Desativa idle esquerdo
            }
        }
        else // Quando não está se movendo
        {
            animator.SetBool("isRunning", false);

            // Atualiza o idle de acordo com o facing
            if (isFacingRight)
            {
                animator.SetBool("isIdleRight", true);
                animator.SetBool("isIdleLeft", false);
            }
            else
            {
                animator.SetBool("isIdleLeft", true);
                animator.SetBool("isIdleRight", false);
            }
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Aplica a força de pulo
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight; // Alterna a direção
        Vector3 scale = transform.localScale;
        scale.x *= -1; // Inverte a escala no eixo X
        transform.localScale = scale; // Aplica a nova escala
    }
}
