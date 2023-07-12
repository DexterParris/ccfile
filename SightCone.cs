using UnityEngine;

public class SightCone : MonoBehaviour
{
    // The angle of the sight cone (in degrees)
    public float angle = 45f;

    // The distance that the sight cone can reach
    public float distance = 5f;

    // The layer mask to use for the sight cone
    public LayerMask layerMask;

    void Update()
    {
        // Get the direction that the sight cone should face
        Vector3 direction = transform.forward;

        // Perform a raycast to check for objects in the sight cone
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, distance, layerMask))
        {
            // The sight cone hit something, so do something here
            // You can access the object that was hit using the hit.collider property
            Debug.Log("Sight cone hit " + hit.collider.gameObject.name);
        }
    }

    private void OnDrawGizmos()
    {
        // Draw the sight cone in the editor for debugging purposes
        Gizmos.color = Color.yellow;
        Vector3 direction = transform.forward;
        Gizmos.DrawRay(transform.position, direction * distance);

        // Draw the arc at the end of the sight cone
        Vector3 right = Quaternion.AngleAxis(angle / 2, Vector3.up) * direction;
        Vector3 left = Quaternion.AngleAxis(-angle / 2, Vector3.up) * direction;
        Gizmos.DrawRay(transform.position + direction * distance, right * distance);
        Gizmos.DrawRay(transform.position + direction * distance, left * distance);
    }
}