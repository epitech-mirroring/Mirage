using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class gun : MonoBehaviour
{   
    public InputActionReference shootAction;
    public GameObject bullet;
    public Transform canon;
    public AudioSource shot;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shootAction.action.performed += shoot;
    }

    private void shoot(InputAction.CallbackContext context)
    {
        var bulletScript = Instantiate(bullet, canon.position, bullet.transform.rotation).GetComponent<bullet>();  
        bulletScript.gun = this.canon;
        shot.Play();
    }
    // Update is called once per frame
    void Update()
    {
           
    }
}
