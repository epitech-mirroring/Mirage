using UnityEngine;

public class Teleport_Mirrors : MonoBehaviour
{
    public GameObject mirror_output;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player") || collider.CompareTag("Monster")) {
            collider.gameObject.transform.position = mirror_output.transform.GetChild(0).position;
        }
    }
}
