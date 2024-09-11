using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static TeamInfosController;

public static class GiftReceiveSystem
{
    public static readonly string SUCCESS_TO_ADD_SOLDIER = "adding soldier successfully";

    public static readonly string FAILED_TO_ADD_SOLDIER = "failed when adding soldier";

    public static SaveSystem saveSystem = SaveSystem.getInstance();
    public static string addNewSoldierToPlayerData(PlayerSoliderScriptableObject newSoldierReceive) {

        string dataFromSoldierNotBrings = SaveSystem.getInstance().getDataFromSpecifedFile(SaveSystem.SOLDIER_PLAYER_NOT_BRINGS_FILE);

        string dataFromSoldierBrings = SaveSystem.getInstance().getDataFromSpecifedFile(SaveSystem.SOLDIER_PLAYER_BRINGS_FILE);

        ItemListData currentSoldiersNotBring = JsonUtility.FromJson<ItemListData>(dataFromSoldierNotBrings);

        ItemListData currentSoldiersBring = JsonUtility.FromJson<ItemListData>(dataFromSoldierBrings);

        bool isPlayerHavingSoldierAsReward = currentSoldiersBring.itemBringsData.Contains(newSoldierReceive) || currentSoldiersNotBring.itemBringsData.Contains(newSoldierReceive);

        if (!isPlayerHavingSoldierAsReward)
        {

            currentSoldiersNotBring.itemBringsData.Add(newSoldierReceive);

            string dataToJson = JsonUtility.ToJson(currentSoldiersNotBring);

            saveSystem.saveDataIntoSpecifiedFile(dataToJson, SaveSystem.SOLDIER_PLAYER_NOT_BRINGS_FILE);

            return SUCCESS_TO_ADD_SOLDIER;

        }

        return FAILED_TO_ADD_SOLDIER;

    }

}
