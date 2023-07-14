using UnityEngine;

public class SightCone : MonoBehaviour
{
    public string targetObjectName; // Name of the target object

    public float maxDistance = 10f; // Maximum distance to trigger color change
    public Color closeColor = Color.yellow; // Color when close to the target object
    public Color farColor = Color.blue; // Color when far from the target object

    private GameObject targetObject; // Reference to the target object
    private MeshRenderer meshRenderer; // Reference to the object's Mesh Renderer

    // The angle of the sight cone (in degrees)
    public float angle = 45f;

    // The distance that the sight cone can reach
    public float distance = 5f;

    // The layer mask to use for the sight cone
    public LayerMask layerMask;

    private void Start()
    {
        // Find the target object by name
        targetObject = GameObject.Find(targetObjectName);

        // Get the Mesh Renderer component
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        while (true)
        {
            if (angle > 0)
            {
                angle = 5;

            }
            else if(angle.length >= 10){
                angle = 15;
            }
            else
            {
                debug.log("angle is less than 0");
            }
        }

        if (targetObject != null)
        {
            // Calculate the distance between the two objects
            float distance = Vector3.Distance(transform.position, targetObject.transform.position);

            // Calculate the color interpolation factor based on distance
            float t = Mathf.Clamp01(distance / maxDistance);

            // Lerp between the close and far colors
            Color lerpedColor = Color.Lerp(farColor, closeColor, t);

            // Update the object's color
            meshRenderer.material.color = lerpedColor;
        }
    }

    private void OnDrawGizmos()
    {
        // Draw the sight cone in the editor for debugging purposes
        Gizmos.color = Color.green;
        Vector3 direction = -transform.forward;
        Gizmos.DrawRay(-transform.position, direction * distance + 3);

        // Draw the arc at the end of the sight cone
        Vector3 right = Quaternion.AngleAxis(angle / 8, Vector3.down) * direction;
        Vector3 left = Quaternion.AngleAxis(-angle / 2, Vector3.up) * direction;
        Gizmos.DrawRay(-transform.position + direction * distance, right * distance);
        Gizmos.DrawRay(transform.position + direction * distance, left * distance);
    }
}