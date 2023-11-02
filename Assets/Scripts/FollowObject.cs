using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform target;       // El GameObject que seguirá la cámara
    public Vector3 offset;         // Offset opcional para ajustar la posición de la cámara
    public float distance = 5.0f;  // Distancia entre la cámara y el objeto
    public float smoothSpeed = 5.0f; // Velocidad de suavizado

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (target == null)
            return;

        // Calcula la posición a la que la cámara debe moverse
        Vector3 desiredPosition = target.position - (transform.forward * distance) + offset;

        // Aplica la posición deseada a la cámara de manera suave
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed * Time.deltaTime);

        // Hace que la cámara mire hacia el objetivo
        //transform.LookAt(target);



    }
}
