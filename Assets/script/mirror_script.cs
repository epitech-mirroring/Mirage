using UnityEngine;
using System.Collections;

public class mirror_script : MonoBehaviour
{
    private GameObject player;
    public GameObject reflectionProb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
<<<<<<< Updated upstream
        reflectionProb.SetActive(false);
=======
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            reflectionProb.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            reflectionProb.SetActive(false);
    }
}
