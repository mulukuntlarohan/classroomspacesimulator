using UnityEngine;

public class ObjectManipulatorLargeScale : MonoBehaviour
{
    private float rotationSpeed = 1.5f; // Speed for rotation
    private float moveSpeed = 0.01f;    // Speed for smooth movement
    private float zoomSpeed = 0.0001f;  // Speed for scaling

    private Vector3 minScale = new Vector3(1.738773f, 1.738773f, 1.738773f); // Minimum scale
    private Vector3 maxScale = new Vector3(6.055154f, 6.055154f, 6.055154f); // Maximum scale

    void Update()
    {
        HandleMouseInput();
    }

    private void HandleMouseInput()
    {
        // Rotate with left mouse button
        if (Input.GetMouseButton(0))
        {
            float rotationX = Input.GetAxis("Mouse X") * rotationSpeed * 10f;
            float rotationY = Input.GetAxis("Mouse Y") * rotationSpeed * 10f;

            transform.Rotate(Vector3.up, -rotationX, Space.World);
            transform.Rotate(Vector3.right, rotationY, Space.World);
        }

        // Zoom with mouse scroll
        if (Input.mouseScrollDelta.y != 0)
        {
            ZoomObject(Input.mouseScrollDelta.y * zoomSpeed);
        }

        // Move with right mouse button
        if (Input.GetMouseButton(1))
        {
            float moveX = Input.GetAxis("Mouse X") * moveSpeed;
            float moveY = Input.GetAxis("Mouse Y") * moveSpeed;

            MoveObject(moveX, moveY);
        }
    }

    private void ZoomObject(float deltaMagnitudeDiff)
    {
        // Calculate new scale and clamp within defined range
        Vector3 newScale = transform.localScale + Vector3.one * deltaMagnitudeDiff;
        newScale.x = Mathf.Clamp(newScale.x, minScale.x, maxScale.x);
        newScale.y = Mathf.Clamp(newScale.y, minScale.y, maxScale.y);
        newScale.z = Mathf.Clamp(newScale.z, minScale.z, maxScale.z);
        transform.localScale = newScale;
    }

    private void MoveObject(float deltaX, float deltaY)
    {
        // Adjust position incrementally for smoother movement
        transform.position += new Vector3(deltaX, deltaY, 0);
    }
}
