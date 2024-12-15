using System.Collections;
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
                StartCoroutine(Take());
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
    private IEnumerator Take()
    {
        take.action.Disable();
        for (int i = 0; i < gameObject.transform.childCount; i++)
            if (gameObject.transform.GetChild(i).gameObject != gameObject)
                gameObject.transform.GetChild(i).gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        if (istrap)
            player.GetComponent<Player>().traps++;
        else if (isammo)
            player.GetComponent<Player>().ammos++;
        yield return new WaitForSeconds(0.5f);
        player.GetComponent<Player>().can_place_trap = true;
        canTake = false;
        take.action.Enable();
        Destroy(gameObject);
    }
}
