using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveRange = 5f; // Range in which the object can move
    public float rotationSpeed = 50f; // Speed of rotation
    public float scaleSpeed = 0.5f; // Speed of scale change

    private Vector3 initialPosition; // Initial position of the object
    private float scaleDirection = 1f; // Direction of scale change



    // Reference to target game object
    public Transform target;

    public float maxSpeed = 10.0f;

    // Acceleration of enemy
    public float acceleration = 5.0f;

    public float height = 10.0f;

    private Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        rigidbody.height = height;
        rigidbody.maxSpeed = maxSpeed;
        rigidbody.acceleration = acceleration - 10f;

        // Store the initial position of the object
        initialPosition = transform.position;

    }

    void Update()
    {
        if (rigidbody != null)
        {
            float currentSpeed = rigidbody.velocity.magnitude;
        }

        Vector3 randomOffset = new Vector3(Random.Range(-moveRange, moveRange), Random.Range(-moveRange, moveRange), Random.Range(-moveRange, moveRange));
        transform.position = initialPosition + randomOffset;

        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        float newScale = transform.localScale.x + scaleSpeed * scaleDirection * Time.deltaTime;
        transform.localScale = new Vector3(newScale, newScale, newScale);

        if (newScale >= 2f || newScale <= 0.5f)
        {
            scaleDirection *= -1f;
        }
    }

    
}