using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    public Transform target;      // anything i want the camera to follow
    public Vector3 offset;        // How far the camera should stay from knight
    public float smoothSpeed = 0.125f;  // how smooth the camera follows

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredPosition = target.position + offset;  // Where the camera *wants* to go
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // Smooth movement
        transform.position = smoothedPosition;  // Actually move the camera
    }
}
