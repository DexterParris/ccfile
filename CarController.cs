using UnityEngine;

public class CarController : MonoBehaviour
{
    // Reference to third person camera
    public Camera thirdPersonCamera;

    // Distance of camera to vehicle
    public float cameraDistance = 5.0f;

    // Maximum speed of vehicle
    public float maxSpeed = 10.0f;

    // Acceleration of vehicle
    public float acceleration = 5.0f;

    // Height of vehicle above ground
    public float height = 1.0f;

    // Rigidbody component of vehicle
    private Rigidbody rigidbody;

    void Start()
    {
        // Get rigidbody component
        rigidbody = GetComponent<Rigidbody>();

        // Lock and hide mouse cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Rotate camera around vehicle when holding right mouse button
        if (Input.GetMouseButton(1))
        {
            float pitch = Input.GetAxis("Mouse X");
            thirdPersonCamera.transform.RotateAround(transform.position, Vector3.up, pitch);
        }

        // Update camera position and rotation
        thirdPersonCamera.transform.position = transform.position - thirdPersonCamera.transform.forward * cameraDistance;
        thirdPersonCamera.transform.LookAt(transform);
    }

    void FixedUpdate()
    {
        // Get input from wsad keys
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate current speed
        float speed = rigidbody.velocity.magnitude;

        // Clamp vertical input to range [-1, 1]
        vertical = Mathf.Clamp(vertical, -1, 1);

        // Calculate desired velocity
        Vector3 velocity = transform.forward * vertical * maxSpeed;

        // Calculate force to apply to rigidbody
        Vector3 force = (velocity - rigidbody.velocity) * acceleration;

        // Apply force to rigidbody
        rigidbody.AddForce(force);

        // Rotate vehicle based on horizontal input
        transform.Rotate(0, horizontal, 0);

        // Keep vehicle at constant height above ground
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit))
        {
            if(hit.collider.tag != "cubeB")
            {
                rigidbody.position = hit.point + transform.up * height;

            }
        }
    }
}