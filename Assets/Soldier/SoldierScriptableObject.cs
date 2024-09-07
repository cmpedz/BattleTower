
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/soldierData")]
public class SoldierScriptableObject : ItemScriptableObject
{
    public float soldierHealth;

    public float speed;

    public float speedAttack;

    public float dam;

    public float defence;

    public AnimatorOverrideController animatorController;

    public LayerMask type;

    public LayerMask objectAttack;

    public float rangeAttack;

    public int quantitiesEnemiesAttack;

    public int direction;

    public float timeCauseDam;


    
}
