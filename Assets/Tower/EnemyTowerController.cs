using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyTowerController : TowerController
{
    public override void eventsWhenTowerIsDefeated()
    {
        Debug.Log("Winner");
    }
}
