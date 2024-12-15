using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Item : MonoBehaviour
{
    public GameObject tooltips;
    private GameObject player;

    public InputActionReference take;
    bool canTake = false;

    public bool isammo = false;
    public bool istrap = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        take.action.Enable();
        take.action.performed += ctx => {
            if (canTake) {
                if (istrap)
                    player.GetComponent<Player>().traps++;
                else if (isammo)
                    player.GetComponent<Player>().ammos++;
                canTake = false;
                Destroy(gameObject);
            }
        };
        tooltips.SetActive(false);
    }

    void Update()
    {
        tooltips.transform.LookAt(Camera.main.transform);
        tooltips.transform.Rotate(0, 180, 0);
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
