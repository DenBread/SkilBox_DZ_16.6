using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed; // �������� ����������
    public float power; // ���� ������
    public bool onGround;
    public Transform groundCheck;
    public float checkRadius = 0.3f;
    public LayerMask groundLayerMask;


    private Rigidbody2D _rb;
    private Controller _controller;

    private void Awake()
    {
        _controller = new Controller(); // ��������� ���������� ��� �������
        _controller.Main.Jump.performed += context => Jump(); // ��������� ����� ������ � ���������� (������ ��� ����, ����� �� ������)

        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _controller.Enable();
    }

    private void OnDisable()
    {
        _controller.Disable();
    }


    private void FixedUpdate()
    {
        ChecingGround();
        Run();
    }

    private void Run()
    {
        _rb.AddForce(Vector2.right * speed * Time.deltaTime, ForceMode2D.Force);
    }

    /// <summary>
    /// ������ ������
    /// </summary>
    private void Jump()
    {
        if (onGround)
        {
            _rb.AddForce(Vector2.up * power * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }
    }

    /// <summary>
    /// �������� ������������� ����� �������� ��������
    /// </summary>
    private void ChecingGround()
    {
        onGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayerMask);
    }
}
