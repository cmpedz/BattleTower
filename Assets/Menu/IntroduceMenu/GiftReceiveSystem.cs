using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static SetUpDataForTeamInfos;

public static class GiftReceiveSystem
{
    public static readonly string SUCCESS_TO_ADD_SOLDIER = "adding soldier successfully";

    public static readonly string FAILED_TO_ADD_SOLDIER = "failed when adding soldier";

    public static SaveSystem saveSystem = SaveSystem.getInstance();
    public static string addNewSoldierToPlayerData(PlayerSoliderScriptableObject newSoldierReceive) {

        string newSoldierName = newSoldierReceive.name;

        string dataFromSoldiersNotBrings = SaveSystem.getInstance().getDataFromSpecifedFile(SaveSystem.SOLDIERS_PLAYER_NOT_BRINGS_FILE);

        string dataFromSoldiersBrings = SaveSystem.getInstance().getDataFromSpecifedFile(SaveSystem.SOLDIERS_PLAYER_BRINGS_FILE);

        ItemListData currentSoldiersNotBring = JsonUtility.FromJson<ItemListData>(dataFromSoldiersNotBrings);

        ItemListData currentSoldiersBring = JsonUtility.FromJson<ItemListData>(dataFromSoldiersBrings);

        bool isPlayerHavingSoldierAsReward = currentSoldiersBring.itemsBringsName.Contains(newSoldierName) || currentSoldiersNotBring.itemsBringsName.Contains(newSoldierName);

        if (!isPlayerHavingSoldierAsReward)
        {

            currentSoldiersNotBring.itemsBringsName.Add(newSoldierName);

            string dataToJson = JsonUtility.ToJson(currentSoldiersNotBring);

            saveSystem.saveDataIntoSpecifiedFile(dataToJson, SaveSystem.SOLDIERS_PLAYER_NOT_BRINGS_FILE);

            return SUCCESS_TO_ADD_SOLDIER;

        }

        return FAILED_TO_ADD_SOLDIER;

    }

}
