using Unity.VisualScripting;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 20f;

    public Transform canon;

    Vector3 dir;

    void Start()
    {
        if (canon)
            dir = canon.forward;
    }

    // Update is called once per frame
    void Update()
    {
        if (dir != null)
            transform.position += dir * speed * Time.deltaTime;
    }
}
