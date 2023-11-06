using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActions : MonoBehaviour
{
 public Transform player;
    [SerializeField] private float initialHealth = 100f;
    [SerializeField] public float moveDistance = 1f;
    [SerializeField] public float moveDuration = 2f; 

    private Rigidbody rb;
    private float currentHealth;
    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private float moveStartTime;
    private Vector3 originalPosition; // Store the original position.

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        currentHealth = initialHealth;
        originalPosition = transform.position;
        targetPosition = originalPosition;
        initialPosition = originalPosition;
    }

    void Update()
    {
        // Smoothly follow the player's position along the X and Z axes.
        float movementSpeed = 3f;
        Vector3 targetPositionXZ = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPositionXZ, movementSpeed * Time.deltaTime);

        if (Time.time - moveStartTime < moveDuration)
        {
            // Interpolate the position for a smooth movement.
            float t = (Time.time - moveStartTime) / moveDuration;
            transform.position = Vector3.Lerp(initialPosition, targetPosition, t);
        }
    }

    public void MoveBack(Vector3 direction)
    {
        initialPosition = transform.position;
        targetPosition = initialPosition + direction * moveDistance;
        moveStartTime = Time.time;
    }

    public void ApplyDamage(float damage)
    {
        if (currentHealth <= 0)
            return;

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Destruct();
        }
    }

    private void Destruct()
    {
        Destroy(gameObject);
    }
}
