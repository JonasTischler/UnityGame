using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Referência ao personagem
    public float smoothSpeed = 0.125f; // Velocidade do movimento suave da câmera
    public Vector3 offset; // Offset da posição da câmera em relação ao personagem

    void LateUpdate()
    {
        // Posição desejada da câmera (com o offset)
        Vector3 desiredPosition = new Vector3(player.position.x + offset.x, transform.position.y, transform.position.z);

        // Movimento suave da câmera para a posição desejada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Aplicar a nova posição à câmera
        transform.position = smoothedPosition;
    }
}
