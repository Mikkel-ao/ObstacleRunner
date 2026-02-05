using UnityEngine;

/// <summary>
/// Controls the rotation of an obstacle plane using physics-based angular velocity.
/// The plane rotates continuously around a specified axis at a constant speed.
/// </summary>
public class ObPlaneMovement : MonoBehaviour
{
    /// <summary>
    /// The Rigidbody component that handles the rotation physics.
    /// </summary>
    [SerializeField] private Rigidbody obPlaneRigidbody;
    
    /// <summary>
    /// The axis around which the plane rotates (default is Y-axis).
    /// </summary>
    [SerializeField] private Vector3 rotationAxis = Vector3.up;
    
    /// <summary>
    /// The rotation speed in degrees per second.
    /// </summary>
    [SerializeField] private float rotationSpeed = 100f;

    /// <summary>
    /// Initializes the Rigidbody component and sets up the initial rotation.
    /// Validates that a Rigidbody component exists and configures physics settings.
    /// </summary>
    void Start()
    {
        // Attempt to get the Rigidbody component if not assigned in the Inspector
        if (obPlaneRigidbody == null)
        {
            obPlaneRigidbody = GetComponent<Rigidbody>();
            if (obPlaneRigidbody == null)
            {
                Debug.LogError(name + " Rigidbody component not found.");
                enabled = false;
                return;
            }
        }

        // Configure the Rigidbody for rotation without gravity
        obPlaneRigidbody.isKinematic = false;
        obPlaneRigidbody.useGravity = false;

        // Convert rotation speed from degrees to radians and calculate angular velocity
        Vector3 angVel = rotationAxis.normalized * rotationSpeed * Mathf.Deg2Rad;
        
        // Ensure the Rigidbody can handle the calculated angular velocity
        obPlaneRigidbody.maxAngularVelocity = Mathf.Max(obPlaneRigidbody.maxAngularVelocity, angVel.magnitude);
        
        // Apply the initial angular velocity to start rotation
        obPlaneRigidbody.angularVelocity = angVel;
    }

    /// <summary>
    /// Updates the rotation every physics frame to maintain consistent rotation speed.
    /// This ensures the angular velocity remains constant even if affected by other forces.
    /// </summary>
    void FixedUpdate()
    {
        obPlaneRigidbody.angularVelocity = rotationAxis.normalized * rotationSpeed * Mathf.Deg2Rad;
    }
}