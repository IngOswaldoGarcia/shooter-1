using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActions : MonoBehaviour
{
    public Transform player;
    private Rigidbody rb;

    [SerializeField] private float _initialHealth;
    private float _currentHealth;

    [SerializeField] public float moveDistance;
    [SerializeField] public float moveDuration = 0.000001f; // Adjust this value to control the smoothness of the movement.

    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private float moveStartTime;

    private Vector3 originalPosition; // Store the original position.

    // Start is called before the first frame update

    void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        _currentHealth = _initialHealth;
        originalPosition = transform.position;
    }
    void Start()
    {
        transform.position = originalPosition;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(this.player.position.x, this.transform.position.y, this.player.position.z), 3 * Time.deltaTime);
        if (Time.time - moveStartTime < moveDuration)
        {
            // Interpolate the position for a smooth movement

            float t = (Time.time - moveStartTime) / moveDuration;
            Debug.Log("Time.time " + Time.time);
            Debug.Log("moveStartTime " + moveStartTime);
            Debug.Log("moveDuration " + moveDuration);
            Debug.Log("t "+ t);
            transform.position = Vector3.Lerp(initialPosition, targetPosition, t);
        }
    }

    public void MoveBack(Vector3 direction)
    {
        initialPosition = transform.position;
        targetPosition = initialPosition + direction * moveDistance;
        moveStartTime = Time.time;
    }

    public void ApplyDamage(float damage){
        //Debug.Log("damage applied" + _currentHealth);
        if(_currentHealth <= 0) return;

        _currentHealth -= damage;

        if(_currentHealth <= 0){
            Destruct();
        }
    }
    private void Destruct(){
        Destroy(gameObject);
    }
}
