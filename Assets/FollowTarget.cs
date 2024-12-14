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
        _anim.SetFloat(Speed, _agent.velocity.magnitude / Time.deltaTime);
        if (_anim.GetFloat(Speed) != 0.0f) {
            _anim.SetBool(IsMoving, true);
        } else {
            _anim.SetBool(IsMoving, false);
        }
        _agent.SetDestination(target.position);
        _oldTransform = gameObject.transform;
    }
}
