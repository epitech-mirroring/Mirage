using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using Cursor = UnityEngine.Cursor;

public class Player : MonoBehaviour
{
    public InputActionReference move;
    public InputActionReference sprint;
    public InputActionReference jump;
    private CharacterController _controller;
    private Animator _anim;
    [FormerlySerializedAs("MaxSpeed")] public float maxSpeed = 2;
    private float _speed = 5;
    private bool _isGrounded = false;
    private bool _jumpPressed = false;
    public float gravity = -9.81f;
    public float jumpHeight = 5.0f;
    private float _playerSpeed = 0;
    private Vector3 _velocity;

    public InputActionReference interact;
    public GameObject trap;

    public int ammos = 0;
    public int traps = 2;
    [FormerlySerializedAs("ammotext")] public TextMeshProUGUI ammoText;
    [FormerlySerializedAs("traptext")] public TextMeshProUGUI trapText;
    void Start()
    {
        _controller = gameObject.GetComponent<CharacterController>();
        _anim = gameObject.GetComponent<Animator>();
        move.action.Enable();
        sprint.action.Enable();
        jump.action.Enable();

        interact.action.Enable();
        interact.action.performed += PlaceTrap;
        
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void PlaceTrap(InputAction.CallbackContext obj)
    {
        if (traps > 0)
        {
            traps--;
            Update_UI();
            Instantiate(trap, gameObject.transform.position, Quaternion.identity);
        }
    }

    void Update_UI()
    {
        ammoText.SetText("x" + ammos.ToString());
        trapText.SetText("x" + traps.ToString());
    }

    void Update()
    {
        Move();
        Sprint();
        Jump();
        if (jump.action.ReadValue<float>() > 0)
            OnJump();
        Anim();
        Update_UI();
    }

    void Anim()
    {
        if (_playerSpeed != 0)
            _anim.SetBool("isMoving", true);
        else
            _anim.SetBool("isMoving", false);
        _anim.SetFloat("Speed", _playerSpeed);
        _anim.SetBool("isGrounded", _isGrounded);
        _anim.SetFloat("Velocity", _velocity.y);
    }

    void Move()
    {
        //POSITION MOVE
        Vector2 direction = move.action.ReadValue<Vector2>();
        float deltatime = Time.deltaTime;
        Vector3 pos = new Vector3(direction.x * deltatime * _speed, 0, direction.y * deltatime * _speed);
        pos.Normalize();
        pos = Camera.main.transform.TransformDirection(pos) * (_speed * deltatime);
        pos.y = 0;
        _playerSpeed = Vector3.Distance(gameObject.transform.position, gameObject.transform.position + pos) / deltatime;
        _controller.Move(pos);
    }

    void Sprint()
    {
        //SPRINT
        if (sprint.action.ReadValue<float>() > 0)
            _speed += 0.1f;
        else
            _speed -= 0.1f;
        //LIMIT SPEED
        if (_speed >= maxSpeed * 5)
            _speed = maxSpeed * 5;
        else if (_speed <= maxSpeed)
            _speed = maxSpeed;
    }

    void OnJump() {
        if (_controller.velocity.y == 0) {
            _jumpPressed = true;
        }
    }

    void Jump()
    {
        if (_jumpPressed && _isGrounded) {
            _velocity.y += Mathf.Sqrt(jumpHeight * -1.0f * gravity);
            _jumpPressed = false;
        }
        _velocity.y += gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);
        _isGrounded = _controller.isGrounded;
    }

    void OnDisable()
    {
        move.action.Disable();
        sprint.action.Disable();
        jump.action.Disable();
    }
}
