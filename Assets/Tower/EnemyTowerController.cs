using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTowerController : TowerController
{
    public override void eventWhenTowerDefeated()
    {
        Debug.Log("Winner");
    }

 
}
