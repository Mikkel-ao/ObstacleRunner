using UnityEngine;

public class ObPlaneMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody obPlaneRigidbody;
    [SerializeField] private Vector3 rotationAxis = Vector3.up;
    [SerializeField] private float rotationSpeed = 180f;

    void Start()
    {
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

        // Ensure physics rotation works
        obPlaneRigidbody.isKinematic = false;
        obPlaneRigidbody.useGravity = false;

        Vector3 angVel = rotationAxis.normalized * rotationSpeed * Mathf.Deg2Rad;
        obPlaneRigidbody.maxAngularVelocity = Mathf.Max(obPlaneRigidbody.maxAngularVelocity, angVel.magnitude);
        obPlaneRigidbody.angularVelocity = angVel;
    }

    void FixedUpdate()
    {
        obPlaneRigidbody.angularVelocity = rotationAxis.normalized * rotationSpeed * Mathf.Deg2Rad;
    }
}