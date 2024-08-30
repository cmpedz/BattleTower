using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleDataStorage : MonoBehaviour
{

    private static BattleDataStorage instance;
    public static BattleDataStorage Instance { 
          get { return instance; }
          private set { instance = value; }
    }

    private BattleDataStorage() { }

    // Start is called before the first frame update
    private LevelScriptableObject currentLevelData;
    public LevelScriptableObject CurrentLevelData
    {
        get { return currentLevelData; }

        set { currentLevelData = value; }
    }

    

    void Start()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);

        }
        else { 

            if(instance != this)
            {
                Destroy(gameObject);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
