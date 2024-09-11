using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SetUpDataForTeamInfos;

public class InitialFileHandle : MonoBehaviour
{
    // Start is called before the first frame update

    private SaveSystem saveSystem = SaveSystem.getInstance();
    void Start()
    {
        initGameStatus();

        initFileToSaveSoldiersPlayerHas(SaveSystem.SOLDIERS_PLAYER_BRINGS_FILE);

        initFileToSaveSoldiersPlayerHas(SaveSystem.SOLDIERS_PLAYER_NOT_BRINGS_FILE);

    }

    private void initGameStatus()
    {

        if (!saveSystem.checkSpecifiedFileExsist(SaveSystem.FILE_SAVE_GAME_STATUS))
        {
            GameStatus gameStatus = new GameStatus();

            gameStatus.isNewbie = true;

            string gameStatusToJson = JsonUtility.ToJson(gameStatus);

            saveSystem.saveDataIntoSpecifiedFile(gameStatusToJson, SaveSystem.FILE_SAVE_GAME_STATUS);
        }
       

    }

    private void initFileToSaveSoldiersPlayerHas(string fileName) {

        if (!saveSystem.checkSpecifiedFileExsist(fileName)) {

            ItemListData itemListData = new ItemListData();

            string itemListDataToJson = JsonUtility.ToJson(itemListData);

            saveSystem.saveDataIntoSpecifiedFile(itemListDataToJson, fileName);

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
