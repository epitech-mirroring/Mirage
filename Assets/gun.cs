using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Gun : MonoBehaviour
{   
   
    public GameObject bulletPrefab;
    public Transform canonGun;
    public float speedBullet = 20f;

    public AudioSource shoot;

    public InputActionReference shot;

    GameObject player;
    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        shot.action.Enable();
        shot.action.performed += Shoot;
    }

    private void Shoot(InputAction.CallbackContext context)
    {
        if (player.GetComponent<Player>().ammos <= 0)
            return;
        shoot.Play();
        player.GetComponent<Player>().ammos--;
        Quaternion playrot = player.transform.rotation;
        Vector3 eulerAngles = playrot.eulerAngles;
        Quaternion bulletRot = Quaternion.Euler(90, eulerAngles.y + 5, 0);
        GameObject bullet = Instantiate(bulletPrefab, canonGun.position, bulletRot);
        bullet mouvementBullet = bullet.AddComponent<bullet>();
        mouvementBullet.speed = speedBullet;
        mouvementBullet.canon = canonGun;
        Destroy(bullet, 5.0f);
    }
}
