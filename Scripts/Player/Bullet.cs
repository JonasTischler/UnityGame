using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float vel = 15f; // Velocidade da bala
    public float damage = 10f; // Dano que a bala causa
    public float lifeTime = 3f; // Tempo de vida da bala (em segundos)

    public float Vel
    {
        get { return vel; }
        set { vel = value; }
    }

    private void Start()
    {
        // Destrói a bala automaticamente após o tempo de vida
        Destroy(gameObject, lifeTime);
    }

    private void Move()
    {
        Vector3 aux = transform.position;
        aux.x += vel * Time.deltaTime; // Move a bala no eixo X
        transform.position = aux;
    }

    private void Update()
    {
        Move(); // Chama a função Move a cada frame
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colidiu com: " + collision.gameObject.name); // Verifica o objeto colidido

        if (collision.gameObject.CompareTag("NPCs"))
        {
            Debug.Log("Colidiu com um NPC");

            // Obtém o componente Health do NPC
            Health npcHealth = collision.gameObject.GetComponent<Health>();
            if (npcHealth != null)
            {
                npcHealth.TakeDamage(damage); // Aplica dano ao NPC
                Debug.Log("Dano aplicado: " + damage);
            }
            else
            {
                Debug.LogWarning("Componente Health não encontrado no NPC!");
            }

            Destroy(gameObject); // Destrói a bala ao colidir com um NPC
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Colidiu com uma parede");
            Destroy(gameObject); // Destrói a bala ao colidir com uma parede
        }
    }

}
