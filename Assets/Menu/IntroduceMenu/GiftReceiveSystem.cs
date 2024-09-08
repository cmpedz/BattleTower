using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static TeamInfosController;

public static class GiftReceiveSystem
{

    public static SaveSystem saveSystem = SaveSystem.getInstance();
    public static void addNewSoldierToPlayerData(PlayerSoliderScriptableObject newSoldierReceive) {

        initFileSavingSoldierDataIfNotExist(SaveSystem.SOLDIER_PLAYER_NOT_BRINGS_FILE);

        initFileSavingSoldierDataIfNotExist(SaveSystem.SOLDIER_PLAYER_BRINGS_FILE);

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

        }



    }

    private static void initFileSavingSoldierDataIfNotExist(string fileName) {

        if (saveSystem.checkSpecifiedFileExsist(fileName)) { 

            ItemListData itemListData = new ItemListData();

            string itemListToJson = JsonUtility.ToJson(itemListData);

            saveSystem.saveDataIntoSpecifiedFile(itemListToJson, fileName);
        }
    }
}
