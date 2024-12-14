using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Trap : MonoBehaviour
{
    public Animation anim;
    public bool isOpen = true;
    public bool canOpen = false;
    public GameObject tooltips;
    public GameObject button;
    public Text text;
    
    public AudioSource trapActive; 
    float cooldown = 0f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster") && isOpen) {
            anim.Play("close");
            trapActive.Play();
            isOpen = false;
            cooldown = 25.0f;

            other.GetComponent<NavMeshAgent>().isStopped = true;
            StartCoroutine(ReleaseMonster(other.GetComponent<NavMeshAgent>()));
        }
    }
    
    void Update()
    {
        if (cooldown > 0) {
            cooldown -= Time.deltaTime;
            text.text = (int) cooldown + " s";
            button.SetActive(false);
            canOpen = false;
        } else if (isOpen) {
            text.text = "Pick up";
            button.SetActive(true);
            canOpen = false;
        } else {
            text.text = "Open";
            button.SetActive(true);
            canOpen = true;
        }
    }

    private IEnumerator ReleaseMonster(NavMeshAgent agent)
    {
        yield return new WaitForSeconds(10);
        agent.isStopped = false;
    }
}

