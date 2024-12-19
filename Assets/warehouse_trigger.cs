using UnityEngine;

public class warehouse_trigger : MonoBehaviour
{
    public GameObject nether;

    music_handler n_handler;
    void Start()
    {
        n_handler = nether.GetComponent<music_handler>();
    }
    
    void OnTriggerEnter(Collider collider) {
        n_handler.isInNether = false;
    }
}
