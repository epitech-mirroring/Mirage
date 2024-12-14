using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class FPS : MonoBehaviour
{
    public InputActionReference look;
    public float sensitivityX = 1;
    public float sensitivityY = 1;

    public float rotationY;
    public float MaxY = 60;
    public GameObject player;
    void Start()
    {
        look.action.Enable();
    }

    void Update()
    {
        move_Cam();
    }

    void move_Cam()
    {
        Vector2 rotationInput = look.action.ReadValue<Vector2>();
        //transform.Rotate(Vector3.up, rotationInput.x * sensitivityX * Time.deltaTime);
        player.transform.Rotate(Vector3.up, rotationInput.x * sensitivityX * Time.deltaTime);
        rotationY -= rotationInput.y * sensitivityY * Time.deltaTime;
        rotationY = Mathf.Clamp(rotationY, -MaxY, MaxY);
        Vector3 currentEulerAngles = transform.localEulerAngles;
        currentEulerAngles.x = rotationY;
        transform.localEulerAngles = new Vector3(rotationY , transform.localEulerAngles.y, 0f);
    }

    void OnDisable()
    {
        look.action.Disable();
    }
}
