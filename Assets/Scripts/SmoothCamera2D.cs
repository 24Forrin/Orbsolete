using UnityEngine;

public class SmoothCamera2D : MonoBehaviour
{
    [Header("Target Settings")]
    [SerializeField] private Transform target; // Drag your player here

    [Header("Movement Settings")]
    [SerializeField] private float smoothTime = 0.3f; // Time taken to reach target (higher = more delay)
    [SerializeField] private Vector3 offset = new Vector3(0f, 0f, -10f); // Camera offset (Z is crucial for 2D)

    [Header("Limits (Optional)")]
    [SerializeField] private bool useBounds = false;
    [SerializeField] private Vector2 minBounds;
    [SerializeField] private Vector2 maxBounds;

    private Vector3 currentVelocity = Vector3.zero;

    private void LateUpdate()
    {
        if (target == null) return;

        // Calculate the target position with the offset
        Vector3 targetPosition = target.position + offset;

        // Smoothly move the camera towards the target position
        Vector3 smoothedPosition = Vector3.SmoothDamp(
            transform.position, 
            targetPosition, 
            ref currentVelocity, 
            smoothTime
        );

        // Optional: Clamp the camera to level boundaries so it doesn't show the void
        if (useBounds)
        {
            smoothedPosition.x = Mathf.Clamp(smoothedPosition.x, minBounds.x, maxBounds.x);
            smoothedPosition.y = Mathf.Clamp(smoothedPosition.y, minBounds.y, maxBounds.y);
        }

        // Apply the position
        transform.position = smoothedPosition;
    }
}