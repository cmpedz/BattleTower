using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem
{
    private static SaveSystem instance;

    private static readonly string SAVE_PATH = Application.dataPath + "/Saves";

    public static readonly string SOLDIER_PLAYER_BRINGS_FILE = "SoldierPlayerBringsData.txt";

    public static readonly string SOLDIER_PLAYER_NOT_BRINGS_FILE = "SoldierPlayerNotBringsData.txt";

    public static readonly string FILE_SAVE_GAME_STATUS = "GameStatus.txt";

    private SaveSystem() {

        if (!Directory.Exists(SAVE_PATH)) { 
            Directory.CreateDirectory(SAVE_PATH);
        }
    }

    public static SaveSystem getInstance() {

        if (instance == null)
        {
            instance = new SaveSystem();
        }

        return instance;  
    }


    public void saveDataIntoSpecifiedFile(string data, string fileName) {

        File.WriteAllText(SAVE_PATH + "/" + fileName, data);
    }

    public string getDataFromSpecifedFile(string fileName) { 

        if(checkSpecifiedFileExsist(fileName)) { 
           return File.ReadAllText(SAVE_PATH + "/" + fileName);
        }

        return null;
    }

    public bool checkSpecifiedFileExsist(string fileName) {
        return File.Exists(SAVE_PATH + "/" + fileName);
    }

}
