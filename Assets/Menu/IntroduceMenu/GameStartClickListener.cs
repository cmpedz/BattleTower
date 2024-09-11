
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameStartClickListener : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject loadingScene;

    [SerializeField] private Slider progressBar;

    [SerializeField] private TextMeshProUGUI percentage;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void moveToNextScene(int index) {

        loadingScene.SetActive(true);

        StartCoroutine(handleLoadingBar(index));
    }

    private IEnumerator handleLoadingBar(int indexNextScene) {

        AsyncOperation nextSceneStatus =  SceneManager.LoadSceneAsync(indexNextScene);

        while (!nextSceneStatus.isDone)
        {
            const float MAX_PROGRESS_VALUE = 0.9f;

            float displayProgress = Mathf.Clamp01(nextSceneStatus.progress / MAX_PROGRESS_VALUE);

            progressBar.value = displayProgress;

            percentage.text = displayProgress * 100 + "%";  

            Debug.Log(displayProgress);

            yield return null;
        }
    }
}
