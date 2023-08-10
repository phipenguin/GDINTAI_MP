using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AIPatrolPathBehavior : AIBehaviour
{
    public PatrolPath patrolPath;
    [Range(0.1f, 1.0f)] public float arriveDistance = 1;
    public float waitTime = 0.5f;
    [SerializeField] private bool isWaiting = false;
    [SerializeField] Vector2 currentPatrolTarget = Vector2.zero;
    private bool isInitialized = false;

    private int currentIndex = -1;

    private void Awake()
    {
        if (patrolPath == null)
            patrolPath = GetComponentInChildren<PatrolPath>();
    }

    public override void PerformAction(EnemyController tank, AIDetector detector)
    {
        if (!isWaiting)
        {
            if (patrolPath.Length < 2)
                return;
            if (!isInitialized)
            {
                var currentPathPoint = patrolPath.GetClosestPathPoint(tank.transform.position);
                this.currentIndex = currentPathPoint.Index;
                this.currentPatrolTarget = currentPathPoint.Position;
                isInitialized = true;
            }

            if (Vector2.Distance(tank.transform.position, currentPatrolTarget) < arriveDistance)
            {
                isWaiting = true;
                StartCoroutine(WaitCoroutine());
                return;
            }

            IEnumerator WaitCoroutine()
            {
                yield return new WaitForSeconds(waitTime);
                var nextPathPoint = patrolPath.GetNextPathPoint(currentIndex);
                currentPatrolTarget = nextPathPoint.Position;
                currentIndex = nextPathPoint.Index;
                isWaiting = false;
            }
        }
    }
}
