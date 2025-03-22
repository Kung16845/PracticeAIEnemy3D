using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("Status Enemy")]
    public float currentHP;
    public float maxHP;
    public float currentAttack;
    public float maxAttack;
    public float currentmovespeed;
    public float maxMoveSpeed;
    public float stoppingDistance;
    Vector3 targetMove;
    public Vector3 TargetMove => targetMove;
    [Header("Agent")]
    NavMeshAgent agent;
    public NavMeshAgent Agent => agent;
    [Header("Field of View")]
    [SerializeField] FieldOfView fieldOfView;
    public FieldOfView FieldOfView => fieldOfView;
    [Header("State")]
    public StateMachine currentState;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        Init();
    }
    public void Init()
    {
        agent = GetComponent<NavMeshAgent>();
        SetStatBoss();
        currentState = GameManager.Instance.stateMachineManager.GetStateEnemyByName("Searching");
        currentState.EnterState(this);
    }
    private void SetStatBoss()
    {
        currentmovespeed = maxMoveSpeed;
        currentAttack = maxAttack;
        currentHP = maxHP;

    }

    // Update is called once per frame
    void Update()
    {
        agent.speed = currentmovespeed;
        agent.stoppingDistance = stoppingDistance;

        currentState.UpdateState(this);
    }
    public void MoveToTarget(Vector3 targetPos)
    {
        targetMove = targetPos;
        agent.SetDestination(targetPos);
    }
}
