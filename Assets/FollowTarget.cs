using UnityEngine;
using UnityEngine.AI;

public class FollowTarget : MonoBehaviour
{
    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int IsMoving = Animator.StringToHash("isMoving");
    public Transform target;
    private NavMeshAgent _agent;
    private Transform _oldTransform;
    private Animator _anim;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _oldTransform = gameObject.transform;
        _anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Compute speed
        float speed = Vector3.Distance(_oldTransform.position, gameObject.transform.position) / Time.deltaTime;
        _anim.SetFloat(Speed, speed);
        if (speed <= 0.1f)
        {
            _anim.SetBool(IsMoving, false);
        } else
        {
            _anim.SetBool(IsMoving, true);
        }
        _agent.SetDestination(target.position);
        _oldTransform = gameObject.transform;
    }
}
