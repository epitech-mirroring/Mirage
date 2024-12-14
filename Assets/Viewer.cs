using System.Collections;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class Viewer : MonoBehaviour
{
    [Min(0)]
    public float maxViewDistance = 50;
    
    public NavMeshModifierVolume obstacle;
    
    public NavMeshSurface surface;
    
    public Transform origin;
    void Start()
    {
        StartCoroutine(Coroutine_UpdateNavMesh());
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 hitPoint;
        Vector3 front = origin.forward;
        Vector3 rayOrigin = origin.position + front * 0.5f;
        if (Physics.Raycast(rayOrigin, front, out RaycastHit hit, maxViewDistance))
        {
            hitPoint = hit.point;
        } else
        {
            hitPoint = rayOrigin + front * maxViewDistance;
        }
        Vector3 midPoint = (rayOrigin + hitPoint) / 2;
        obstacle.center = origin.InverseTransformPoint(midPoint);
        obstacle.size = new Vector3(35f, 5f, Vector3.Distance(rayOrigin, hitPoint));
        
    }

    IEnumerator Coroutine_UpdateNavMesh()
    {
        yield return new WaitForSeconds(1f);
        surface.BuildNavMesh();
        StartCoroutine(Coroutine_UpdateNavMesh());
    }
}
