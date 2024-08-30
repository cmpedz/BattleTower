using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyTowerController : TowerController
{
    [SerializeField] private LevelScriptableObject towerData;

    void Awake()
    {
        towerData = BattleDataStorage.Instance.CurrentLevelData;
    }

    void Start()
    {
        defineHealthForHealthBar(towerData.healthTower);

    }

    void Update()
    {
        base.Update();
    }
    public override void eventsWhenTowerIsDefeated()
    {
        Debug.Log("Winner");
    }
}
