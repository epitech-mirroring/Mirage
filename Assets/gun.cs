using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Gun : MonoBehaviour
{   
    public InputActionReference shootAction;
    public GameObject bullet;
    public Transform canon;
    public AudioSource shot;
    public Player player;


    private void Start()
    {
        shootAction.action.Enable();
        shootAction.action.performed += Shoot;
    }

    private void Shoot(InputAction.CallbackContext context)
    {
        if (player.ammos <= 0) return;
        player.ammos--;
        var bulletScript = Instantiate(bullet, canon.position, bullet.transform.rotation).GetComponent<bullet>();  
        bulletScript.gun = canon;
        shot.Play();
    }
}
