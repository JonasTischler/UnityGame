using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Refer�ncia ao personagem
    public float smoothSpeed = 0.125f; // Velocidade do movimento suave da c�mera
    public Vector3 offset; // Offset da posi��o da c�mera em rela��o ao personagem

    void LateUpdate()
    {
        // Posi��o desejada da c�mera (com o offset)
        Vector3 desiredPosition = new Vector3(player.position.x + offset.x, transform.position.y, transform.position.z);

        // Movimento suave da c�mera para a posi��o desejada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Aplicar a nova posi��o � c�mera
        transform.position = smoothedPosition;
    }
}
