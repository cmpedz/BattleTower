using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameStartClickListener : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private ButtonEventsFactory buttonEventsFactory;

    [SerializeField] private int indexNextScene;

    [SerializeField] private PlayerSoliderScriptableObject freeSoldierForNewbie;

    private SaveSystem saveSystem = SaveSystem.getInstance();
    public void OnPointerClick(PointerEventData eventData)
    {
        isPLayerCapableToReceiveNewbieGift();

        buttonEventsFactory.changeScence(indexNextScene);
    }

    private void isPLayerCapableToReceiveNewbieGift()
    {
        string gameStatusFromFile = saveSystem.getDataFromSpecifedFile(SaveSystem.FILE_SAVE_GAME_STATUS);

        GameStatus gameStatus = JsonUtility.FromJson<GameStatus>(gameStatusFromFile);

        if (freeSoldierForNewbie != null && gameStatus.isNewbie)
        {
            GiftReceiveSystem.addNewSoldierToPlayerData(freeSoldierForNewbie);

            gameStatus.isNewbie = false;

            string gameStatusToJson = JsonUtility.ToJson(gameStatus);

            saveSystem.saveDataIntoSpecifiedFile(gameStatusToJson, SaveSystem.FILE_SAVE_GAME_STATUS);
        }

        


    }



    // Start is called before the first frame update
    void Start()
    {
        string fileSaveGameStatusPath = SaveSystem.FILE_SAVE_GAME_STATUS;

        if (!saveSystem.checkSpecifiedFileExsist(fileSaveGameStatusPath)) { 
            
            GameStatus gameStatus = new GameStatus();

            gameStatus.isNewbie = true;

            string gameStatusToJson = JsonUtility.ToJson(gameStatus);

            saveSystem.saveDataIntoSpecifiedFile(gameStatusToJson, fileSaveGameStatusPath);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
