using UnityEngine;

public class PatrolWithRandomTimer : MonoBehaviour
{
    public float speed = 5f; // Velocidade do lobo
    public float minMoveTime = 3f; // Tempo m�nimo (3 segundos)
    public float maxMoveTime = 12f; // Tempo m�ximo (12 segundos)
    private Rigidbody2D rb; // Refer�ncia ao Rigidbody2D
    private bool isFacingRight = true; // Indica se o lobo est� virado para a direita
    private float timer; // Contador de tempo
    public bool canPatrol = true; // Flag para controlar a patrulha

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetRandomTimer(); // Define o timer aleat�rio na inicializa��o
    }

    void Update()
    {
        // S� patrulha se o lobo puder (canPatrol for true)
        if (canPatrol)
        {
            Patrol();
        }
    }

    void Patrol()
    {
        // Move o lobo
        rb.velocity = new Vector2(isFacingRight ? speed : -speed, rb.velocity.y);

        // Atualiza o timer
        timer -= Time.deltaTime;

        // Verifica se � hora de mudar a dire��o
        if (timer <= 0)
        {
            Flip(); // Vira o lobo
            SetRandomTimer(); // Reseta o timer com um novo valor aleat�rio
        }
    }

    private void SetRandomTimer()
    {
        // Define um novo tempo aleat�rio entre minMoveTime (3) e maxMoveTime (12)
        timer = Random.Range(minMoveTime, maxMoveTime);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se o NPC colidiu com uma parede (tag "Wall")
        if (collision.CompareTag("Wall"))
        {
            Flip(); // Muda de dire��o ao colidir com a parede
        }
    }

}
