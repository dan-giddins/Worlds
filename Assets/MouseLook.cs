using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float MouseSensitivity = 100f;
    public Transform PlayerBody;
    private float XRotation = 0f;

    // Start is called before the first frame update
    void Start() =>
        Cursor.lockState = CursorLockMode.Locked;

    // Update is called once per frame
    void Update()
    {
        var mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        var mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;
        XRotation -= mouseY;
        XRotation = Mathf.Clamp(XRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(XRotation, 0, 0);
        PlayerBody.Rotate(Vector3.up * mouseX);
    }
}
