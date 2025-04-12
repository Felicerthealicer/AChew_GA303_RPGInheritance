using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEnemy_RandomizedMovement : BlueEnemy
{
    protected override void PatrolPointCounter()
    {
        if (navAgent.remainingDistance < 0.5f)
        {
            patrolPointIndex = Random.Range (0, patrolPoints.Count);

            if (patrolPointIndex >= patrolPoints.Count)
            {
                patrolPointIndex = 0;
            }
        }
    }
}
