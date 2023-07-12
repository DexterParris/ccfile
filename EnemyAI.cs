using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // Reference to target game object
    public Transform target;

    // Maximum speed of enemy
    public float maxSpeed = 10.0f;

    // Acceleration of enemy
    public float acceleration = 5.0f;

    // Height of enemy above ground
    public float height = 1.0f;

    // Rigidbody component of enemy
    private Rigidbody rigidbody;

    void Start()
    {
        // Get rigidbody component
        rigidbody = GetComponent<Rigidbody>();

        rigidbody.height = height;
        rigidbody.maxSpeed = maxSpeed;
        rigidbody.acceleration = acceleration;

    }

    void Update()
    {
        if (rigidbody != null)
        {
            float currentSpeed = rigidbody.velocity.magnitude;
        }
    }

    
}