using UnityEngine;

public class lab4zad3 : MonoBehaviour
{
    public float speed = 5f;

    private CharacterController characterController;

    public float sensitivityX = 2f;
    public float sensitivityY = 2f;
    private Transform cameraTransform;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        MovePlayer();
        MoveCamera();
    }

    void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;
        moveDirection = transform.TransformDirection(moveDirection);

        characterController.Move(moveDirection * speed * Time.deltaTime);
    }

    void MoveCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        transform.Rotate(Vector3.up * mouseX * sensitivityX);
        float rotationX = cameraTransform.rotation.eulerAngles.x - mouseY * sensitivityY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);
        cameraTransform.rotation = Quaternion.Euler(rotationX, cameraTransform.rotation.eulerAngles.y, cameraTransform.rotation.eulerAngles.z);
    }
}
