using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public BaseBehavior firstBase;
    public BaseBehavior secondBase;
    public BaseBehavior thirdBase;

    public void RespawnTank()
    {
        int spawnPoint = Random.Range(0, 3);

        switch (spawnPoint)
        {
            case 0:
                firstBase.RespawnTank();
                break;
            case 1:
                secondBase.RespawnTank();
                break;
            case 2:
                thirdBase.RespawnTank();
                break;
            default:
                break;
        }
    }
}
