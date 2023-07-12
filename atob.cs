using UnityEngine;

public class atob : MonoBehaviour
{
    public Transform objectA;
    public Transform objectB;
    public float moveSpeed = 5f;
    public float rotateSpeed = 5f;

    void Update()
    {
        // Calculate the distance between the objects
        float distance = Vector3.Distance(objectA.position, objectB.position);

        // If the distance is greater than zero, move and rotate object B to match object A
        if (distance > 0.05f )
        {
            objectB.GetComponent<Rigidbody>().drag = 49;
            // Calculate the direction from object B to object A
            Vector3 direction = objectA.position - objectB.position;

            // Normalize the direction vector to get a unit vector
            direction.Normalize();

            // Apply a force to object B in the direction of object A
            objectB.GetComponent<Rigidbody>().AddForce(direction * moveSpeed, ForceMode.Impulse);

            // Rotate object B towards the rotation of object A
            objectB.rotation = Quaternion.RotateTowards(objectB.rotation, objectA.rotation, rotateSpeed);
        }
        else
        {
            objectB.GetComponent<Rigidbody>().drag = 0;
        }
    }
}