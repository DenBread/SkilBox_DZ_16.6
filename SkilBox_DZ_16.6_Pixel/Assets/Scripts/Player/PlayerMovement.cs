using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed; // скорость премещения
    public float power; // сила прыжка
    public bool onGround;
    public Transform groundCheck;
    public float checkRadius = 0.3f;
    public LayerMask groundLayerMask;


    private Rigidbody2D _rb;
    private Controller _controller;


    private void Awake()
    {
        _controller = new Controller(); // добавляем контроллер над игроком
        _controller.Main.Jump.performed += context => Jump(); // добавляем метод прыжка в контроллер (записи для меня, чтобы не забыть)
        //_controller.Main.Move.performed += Move;

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
        Move();
    }

    private void Move()
    {
        Vector3 horizontal = _controller.Main.Move.ReadValue<Vector2>();
        Debug.Log(horizontal);
        _rb.AddForce(horizontal * speed * Time.fixedDeltaTime, ForceMode2D.Force);
    }

    /// <summary>
    /// Прыжок игрока
    /// </summary>
    private void Jump()
    {
        if (onGround)
        {
            _rb.AddForce(Vector2.up * power * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }
    }

    /// <summary>
    /// Проверка прикосновение земли спомощью триггера
    /// </summary>
    private void ChecingGround()
    {
        //onGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayerMask);
        onGround = true;
    }
}
