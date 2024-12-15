using UnityEngine;
using UnityEngine.InputSystem;

public class Key : MonoBehaviour
{
    public InputActionReference take;
    private GameObject player;
    public GameObject tooltips;

    bool canTake = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        take.action.Enable();
        take.action.performed += ctx => {
            if (canTake) {
                player.GetComponent<Player>().won = true;
                canTake = false;
                Destroy(gameObject);
            }
        };
        tooltips.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        player.GetComponent<Player>().can_place_trap = false;
        tooltips.SetActive(true);
        canTake = true;
    }

    void OnTriggerExit(Collider other)
    {
        player.GetComponent<Player>().can_place_trap = true;
        tooltips.SetActive(false);
        canTake = false;
    }
}
