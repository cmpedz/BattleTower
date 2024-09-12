using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class NewbieGiftsController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Item freeSoldierForNewbie;

    [SerializeField] private ItemList soldiersPlayerNotBrings;

    private SaveSystem saveSystem = SaveSystem.getInstance();

    void Start()
    {
        givePlayerNewbieGifts();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void givePlayerNewbieGifts()
    {
        string gameStatusFromFile = saveSystem.getDataFromSpecifedFile(SaveSystem.FILE_SAVE_GAME_STATUS);

        GameStatus gameStatus = JsonUtility.FromJson<GameStatus>(gameStatusFromFile);


        if (freeSoldierForNewbie != null && gameStatus.isNewbie)
        {

            soldiersPlayerNotBrings.addItem(freeSoldierForNewbie);

            gameStatus.isNewbie = false;

            string gameStatusToJson = JsonUtility.ToJson(gameStatus);

            saveSystem.saveDataIntoSpecifiedFile(gameStatusToJson, SaveSystem.FILE_SAVE_GAME_STATUS);
        }




    }
}
