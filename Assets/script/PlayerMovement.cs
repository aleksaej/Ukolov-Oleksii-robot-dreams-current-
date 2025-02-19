using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float sensitivity = 2f;
    public float jumpHeight = 1.5f;
    public float gravity = -9.81f;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;
    private float rotationX = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; // ������ ������
    }

    void Update()
    {
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // ���������� �� ��������� ��������� ��������
        }

        // �������� WASD
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * speed * Time.deltaTime);

        // ������
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // ������
        }

        // ��������� ����������
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // �������� ������ � ���������
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        transform.Rotate(Vector3.up * mouseX); // ������� ���������
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); // ����������� �� ���������
        Camera.main.transform.localRotation = Quaternion.Euler(rotationX, 0, 0); // �������� ������
    }
}

