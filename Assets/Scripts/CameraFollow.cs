using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;

    public float smoothSpeed = 0.125f;

    public Vector3 offset;

    public Vector3 cameraUp;


    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;

        // Get Target Position
        Vector3 targetPosition = target.position + cameraUp;
        transform.LookAt(targetPosition);

    }

}
