using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEFAULTENEMYAI : MonoBehaviour
{
    [SerializeField]
    private AIBehaviour shootBehaviour, patrolBehaviour;

    [SerializeField]

    private EnemyController tank;
    [SerializeField]
    private AIDetector detector;


    private void Awake()
    {
        detector = GetComponentInChildren<AIDetector>();
        tank = GetComponentInChildren<EnemyController>();
    }

    private void Update()
    {
        if(detector.TargetVisible)
        {
            shootBehaviour.PerformAction(tank, detector);
        }else
        {
            patrolBehaviour.PerformAction(tank, detector);
        }
    }
}
