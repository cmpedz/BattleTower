using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/playerSoldierData")] 
public class PlayerSoliderScriptableObject : SoldierScriptableObject
{

    public float cost;

    public float timeWattingForNextSummon;
}
