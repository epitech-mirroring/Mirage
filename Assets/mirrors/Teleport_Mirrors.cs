using UnityEngine;

public class Teleport_Mirrors : MonoBehaviour
{
    public GameObject mirror_output;
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player") || collider.CompareTag("Monster"))
        {
            Transform spawnPoint = mirror_output.transform.GetChild(0);
            Vector3 targetPosition = spawnPoint.position;
            CharacterController controller = collider.gameObject.GetComponent<CharacterController>();
            if (controller != null)
            {
                controller.enabled = false;
                collider.gameObject.transform.position = targetPosition;
                controller.enabled = true;
            }
            else
            {
                collider.gameObject.transform.position = targetPosition;
            }
        }
    }
}
