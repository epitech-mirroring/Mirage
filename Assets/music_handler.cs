using System;
using Unity.VisualScripting;
using UnityEngine;

public class music_handler : MonoBehaviour
{
    Player player;
    AudioSource music;

    public bool isInNether = false;

    float pitch = 1.0f;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        music = player.GetComponents<AudioSource>()[3];
        music.pitch = 1;
    }

    void Update() {
        if (isInNether) {
            pitch -= 0.1f;
        } else {
            pitch += 0.1f;
        }
        pitch = Math.Clamp(pitch, -1, 1);
        music.pitch = pitch;
    }

    void OnTriggerEnter(Collider collider) {
        isInNether = true;
    }
}
