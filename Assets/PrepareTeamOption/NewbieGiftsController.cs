using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewbieGiftsController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private PlayerSoliderScriptableObject freeSoldierForNewbie;

    [SerializeField] private TextMeshProUGUI textTest;

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

        textTest.text = " , check condition is newbie : " + gameStatus.isNewbie +  " check gift receive :" + freeSoldierForNewbie ;

        if (freeSoldierForNewbie != null && gameStatus.isNewbie)
        {

            textTest.text = GiftReceiveSystem.addNewSoldierToPlayerData(freeSoldierForNewbie);

            gameStatus.isNewbie = false;

            string gameStatusToJson = JsonUtility.ToJson(gameStatus);

            saveSystem.saveDataIntoSpecifiedFile(gameStatusToJson, SaveSystem.FILE_SAVE_GAME_STATUS);
        }




    }
}
