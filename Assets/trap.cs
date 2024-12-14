using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Trap : MonoBehaviour
{
    public Animation anim;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster")) {
            anim.Play("trapanim");
            
            other.GetComponent<NavMeshAgent>().isStopped = true;
            StartCoroutine(ReleaseMonster(other.GetComponent<NavMeshAgent>()));
        }
    }
    
    private IEnumerator ReleaseMonster(NavMeshAgent agent)
    {
        yield return new WaitForSeconds(10);
        agent.isStopped = false;
    }
}

