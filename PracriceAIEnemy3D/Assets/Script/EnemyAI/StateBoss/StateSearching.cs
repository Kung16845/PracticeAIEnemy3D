using UnityEngine;
using System;
using Random = UnityEngine.Random;
using UnityEngine.AI;
[CreateAssetMenu(menuName = "State/State Searching", fileName = "State Searching")]
public class StateSearching : StateMachine
{

    public override void EnterState(Enemy enemy)
    {
        FieldOfView fieldOfView = enemy.FieldOfView;

        if (fieldOfView.canSeePlayer)
        {
            enemy.MoveToTarget(GameManager.Instance.Player.transform.position);
        }
        else
        {
            enemy.MoveToTarget(RandomMoveInArea(enemy));
        }
    }
    public override void UpdateState(Enemy enemy)
    {
        if (enemy.FieldOfView.canSeePlayer)
        {
            ExitState(enemy);
        }
        else if (CheckTargetMove(enemy) && !enemy.FieldOfView.canSeePlayer)
        {
            enemy.MoveToTarget(RandomMoveInArea(enemy));
        }
    }

    public override void ExitState(Enemy enemy)
    {

    }

    private Vector3 RandomMoveInArea(Enemy enemy)
    {
        GameObject area = GameManager.Instance.AreaEnemy;

        Vector3 minArea = area.GetComponent<BoxCollider>().bounds.min;
        Vector3 maxArea = area.GetComponent<BoxCollider>().bounds.max;
        Vector3 randomPoint = new Vector3(Random.Range(minArea.x, maxArea.x), enemy.transform.position.y, Random.Range(minArea.z, maxArea.z));
        NavMeshHit hit;

        if (NavMesh.SamplePosition(randomPoint, out hit, Mathf.Infinity, NavMesh.AllAreas))
        {
            return hit.position; // คืนค่าตำแหน่งที่อยู่บน NavMesh
        }

        return RandomMoveInArea(enemy);
    }
    private bool CheckTargetMove(Enemy enemy)
    {   
        NavMeshAgent agent = enemy.Agent;
        // ตรวจสอบว่า Agent ใกล้ถึงตำแหน่งเป้าหมายหรือไม่
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
