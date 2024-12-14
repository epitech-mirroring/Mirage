using UnityEngine;

public class trap : MonoBehaviour
{
    public Animation anim;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster")) {
            anim.Play("trapanim");
        }
    }
}

