using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform gun;
    private Vector3 forward;
    
    void Start()
    {
        forward = gun.forward;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().Translate(forward);
    }
}
