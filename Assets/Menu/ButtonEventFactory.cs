using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonEventsFactory : MonoBehaviour
{
    private static ButtonEventsFactory instance;

    public static ButtonEventsFactory Instance
    {
        get { return instance; }
    }

    private void Start()
    {
        if (instance == null) {
            instance = this;
        }
        else
        {
            if (instance != this) {
                Destroy(gameObject);
            }
        }
    }
    public void pauseGame() {
        Time.timeScale = 0;
    }

    public void playAgain(){
        changeScence(SceneManager.GetActiveScene().buildIndex);
    }

    public void resumeGame()
    {
        Time.timeScale = 1;
    }

    public void changeScence(int index)
    {
        SceneManager.LoadScene(index);
        Time.timeScale = 1;
    }

    public void quitGameApp() { 
        Application.Quit();
    }


}
