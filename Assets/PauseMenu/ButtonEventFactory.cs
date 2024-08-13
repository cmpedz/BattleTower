using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonEventsFactory: MonoBehaviour
{
    private static ButtonEventsFactory instance;

    public static ButtonEventsFactory Instance
    {
        get { return instance; }
    }

    private void Start()
    {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(instance.gameObject);
        }
        else
        {
            if(instance != this) {
                Destroy(gameObject);
            }
        }
    }
    public void pauseGame() { 
        Time.timeScale = 0;
    }

    public void resumeGame()
    {
        Time.timeScale = 1;
    }



}
