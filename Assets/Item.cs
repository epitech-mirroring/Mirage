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
        tooltips.SetActive(false);
    }

    void Update()
    {
        tooltips.transform.LookAt(Camera.main.transform);
        tooltips.transform.Rotate(0, 180, 0);
        if (canTake && take.action.ReadValue<float>() > 0.0f) {
            if (istrap)
                player.GetComponent<Player>().traps++;
            else if (isammo)
                player.GetComponent<Player>().ammos++;
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        tooltips.SetActive(true);
        canTake = true;
    }

    void OnTriggerExit(Collider other)
    {
        tooltips.SetActive(false);
        canTake = false;
    }
}
