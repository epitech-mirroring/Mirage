using Unity.VisualScripting;
using UnityEngine;

public class die : MonoBehaviour
{
    public AudioSource death;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster")) {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            FollowTarget monster = other.gameObject.GetComponent<FollowTarget>();
            player.GetComponent<Player>().IsDead = true;
            death.Play();
            monster.runBeast.Stop();
            monster.souffle.Stop();
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
