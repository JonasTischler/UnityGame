using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float vel = 2f; // Velocidade do movimento
    private Transform heroTransform; // Referência ao Transform do personagem
    private Rigidbody2D heroRB; // Referência ao Rigidbody2D do personagem
    private Animator animator; // Referência ao Animator do personagem
    private bool face = true; // Inicialmente, o personagem está virado para a direita

    void Start()
    {
        heroTransform = GetComponent<Transform>(); // Obter o componente Transform
        heroRB = GetComponent<Rigidbody2D>(); // Obter o componente Rigidbody2D
        animator = GetComponent<Animator>(); // Obter o componente Animator
    }

    void Update()
    {
        // Lógica de flip
        if (Input.GetKey(KeyCode.RightArrow) && !face)
        {
            Flip();
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && face)
        {
            Flip();
        }

        // Movimento para a direita
        if (Input.GetKey(KeyCode.RightArrow))
        {
            heroTransform.Translate(new Vector2(vel * Time.deltaTime, 0));
            UpdateAnimationState(true); // Muda para a animação de andar
        }
        // Movimento para a esquerda
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            heroTransform.Translate(new Vector2(-vel * Time.deltaTime, 0));
            UpdateAnimationState(true); // Muda para a animação de andar
        }
        else // Parado
        {
            UpdateAnimationState(false); // Muda para a animação de idle
        }
    }

    void Flip()
    {
        face = !face; // Inverte a direção de facing
        Vector3 scale = heroTransform.localScale; // Obtém a escala atual do personagem
        scale.x *= -1; // Inverte a escala no eixo X
        heroTransform.localScale = scale; // Aplica a nova escala
    }

    private void UpdateAnimationState(bool isWalking)
    {
        animator.SetBool("Walk", isWalking); // Define o parâmetro "Walk" no Animator
        animator.SetBool("Idle", !isWalking); // Define o parâmetro "Idle" no Animator
    }
}
