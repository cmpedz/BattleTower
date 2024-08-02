using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObject/levelData")]
public class LevelScriptableObject : ScriptableObject
{
    public float healthTower;

    public float maxTimeSummonEnemy;

    public float minTimeSummonEnemy;

    public float timeWaitToDecreaseTimeSummonEnemy;

    public float timeSummonEnemyDecreaseAmount;

    public List<SoldierScriptableObject> enemiesType;

    public float timeSummonNewType;

    public Sprite levelBackground;

    public Sprite enemyTowerSprite;


}
