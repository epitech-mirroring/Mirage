using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public InputActionReference move;
    public InputActionReference sprint;
    public InputActionReference jump;
    private CharacterController controller;
    private Animator anim;
    public float MaxSpeed = 2;
    private float speed = 5;
    private bool isGrounded = false;
    private bool jump_pressed = false;
    public float gravity = -9.81f;
    public float jumpHeight = 5.0f;
    private float player_speed = 0;
    private Vector3 velocity;
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        anim = gameObject.GetComponent<Animator>();
        move.action.Enable();
        sprint.action.Enable();
        jump.action.Enable();
    }

    void Update()
    {
        Move();
        Sprint();
        Jump();
        if (jump.action.ReadValue<float>() > 0)
            OnJump();
        Anim();
    }

    void Anim()
    {
        if (player_speed != 0)
            anim.SetBool("isMoving", true);
        else
            anim.SetBool("isMoving", false);
        anim.SetFloat("Speed", player_speed);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("Velocity", velocity.y);
    }

    void Move()
    {
        //POSITION MOVE
        Vector2 direction = move.action.ReadValue<Vector2>();
        float deltatime = Time.deltaTime;
        Vector3 pos = new Vector3(direction.x * deltatime * speed, 0, direction.y * deltatime * speed);
        pos.Normalize();
        pos = Camera.main.transform.TransformDirection(pos) * speed * deltatime;
        pos.y = 0;
        player_speed = Vector3.Distance(gameObject.transform.position, gameObject.transform.position + pos) / deltatime;
        controller.Move(pos);
    }

    void Sprint()
    {
        //SPRINT
        if (sprint.action.ReadValue<float>() > 0)
            speed += 0.1f;
        else
            speed -= 0.1f;
        //LIMIT SPEED
        if (speed >= MaxSpeed * 5)
            speed = MaxSpeed * 5;
        else if (speed <= MaxSpeed)
            speed = MaxSpeed;
    }

    void OnJump() {
        if (controller.velocity.y == 0) {
            jump_pressed = true;
        }
    }

    void Jump()
    {
        if (jump_pressed && isGrounded) {
            velocity.y += Mathf.Sqrt(jumpHeight * -1.0f * gravity);
            jump_pressed = false;
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        isGrounded = controller.isGrounded;
        Debug.Log(isGrounded);
    }

    void OnDisable()
    {
        move.action.Disable();
        sprint.action.Disable();
        jump.action.Disable();
    }
}
