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
    private Vector3 initialRotation;

    void Start()
    {
        initialRotation = transform.eulerAngles;
    }
    void LateUpdate()
    {
        if (GameController.instance.player == null) return;

        if (GameController.instance.rightClick){
            Vector3 desiredPosition = GameController.instance.player.transform.position;
            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        } else{
            transform.eulerAngles = initialRotation;
            // Calcula la posición a la que la cámara debe moverse
            Vector3 desiredPosition = GameController.instance.player.transform.position - (transform.forward * distance) + offset;

            // Aplica la posición deseada a la cámara de manera suave
            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed * Time.deltaTime);
        }



    }
}
