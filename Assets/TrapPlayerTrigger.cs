using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class TrapPlayerTrigger : MonoBehaviour
{
    Trap trapscript;
    public InputActionReference interact;
    private bool trigger = false;
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        trapscript = gameObject.GetComponentInParent<Trap>();
        interact.action.Enable();
        interact.action.performed += OpenTrap;
    }

    void OpenTrap(InputAction.CallbackContext obj)
    {
        if (!trapscript)
            return;
        if (!trapscript.isOpen && trapscript.canOpen && trigger) {
            trapscript.anim.Play("open");
            trapscript.isOpen = true;
            trapscript.canOpen = false;
        } else if (trigger && trapscript.isOpen && !trapscript.canOpen && player.GetComponent<Player>().can_pick_trap) {
            StartCoroutine(Destroy_Trap());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            trapscript.tooltips.SetActive(true);
            trigger = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) {
            trapscript.tooltips.SetActive(false);
            trigger = false;
        }
    }

    private IEnumerator Destroy_Trap()
    {
        interact.action.Disable();
        for (int i = 0; i < trapscript.gameObject.transform.childCount; i++)
            if (trapscript.gameObject.transform.GetChild(i).gameObject != gameObject)
                trapscript.gameObject.transform.GetChild(i).gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        player.GetComponent<Player>().traps++;
        yield return new WaitForSeconds(0.5f);
        interact.action.Enable();
        Destroy(trapscript.gameObject);
    }
}
