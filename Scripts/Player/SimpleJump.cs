using UnityEngine;

public class SimpleJump : MonoBehaviour
{
    public float jumpForce = 5f; // For�a do pulo
    public float jumpCooldown = 1f; // Cooldown do pulo em segundos
    private float lastJumpTime = 0f; // Tempo do �ltimo pulo
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obt�m o componente Rigidbody2D
    }

    void Update()
    {
        // Verifica se a tecla de pulo foi pressionada e se o cooldown j� passou
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= lastJumpTime + jumpCooldown)
        {
            Jump(); // Chama o m�todo de pulo
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Aplica a for�a de pulo
        lastJumpTime = Time.time; // Atualiza o tempo do �ltimo pulo
    }
}
