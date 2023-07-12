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
    }

    void FixedUpdate()
    {
        // Calculate direction to target
        Vector3 direction = (target.position - transform.position).normalized;

        // Calculate current speed
        float speed = rigidbody.velocity.magnitude;

        // Calculate desired velocity
        Vector3 velocity = direction * maxSpeed;

        // Calculate force to apply to rigidbody
        Vector3 force = (velocity - rigidbody.velocity) * acceleration;

        // Apply force to rigidbody
        rigidbody.AddForce(force);

        // Rotate enemy towards target
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 5.0f);

        // Keep enemy at constant height above ground
        RaycastHit hit;

        if (Physics.Raycast(transform.position, -transform.up, out hit))
        {
            rigidbody.position = hit.point + transform.up * height;
        }
    }
}