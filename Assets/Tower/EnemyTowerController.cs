using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static SetUpDataForTeamInfos;

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

    new void Update()
    {
        base.Update();
    }
    public override void eventsWhenTowerIsDefeated()
    {

        if(towerData.reward != null)
        {
            ItemCollectController.saveItemDataIntoSpecifiedFile(SaveSystem.SOLDIERS_PLAYER_NOT_BRINGS_FILE, towerData.reward.name, false);
        }
       
    }


}
