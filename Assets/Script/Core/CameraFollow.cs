using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Referência ao jogador
    public Vector3 offset = new Vector3(10, 10, -10); // Offset para a câmera
    public float smoothSpeed = 0.125f; // Velocidade de suavização

    void LateUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
