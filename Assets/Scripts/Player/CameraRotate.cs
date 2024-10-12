using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public float mouseSensivity;
    float mouseX, mouseY;

    public Transform playerBody;

    float xRotation = 0f;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    private void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensivity;
        mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
