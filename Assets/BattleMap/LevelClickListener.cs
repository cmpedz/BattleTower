using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelClickListener : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    [SerializeField] private LevelScriptableObject levelData;

    [SerializeField] private GameObject levelInforsMenu;

    [SerializeField] private TextMeshProUGUI levelName;

    [SerializeField] private GameObject reward;

    public void OnPointerClick(PointerEventData eventData)
    {
        setUpCurrentLevelDisplay();

        setUpDataForLevel();
    }

    private void setUpCurrentLevelDisplay() {

        levelInforsMenu.SetActive(true);

        levelName.text = levelData.levelName;    

        if(levelData.reward != null )
        {
            reward.GetComponent<Image>().sprite = levelData.reward.sprite;
        }
    }

    private void setUpDataForLevel() { 

        BattleDataStorage.Instance.CurrentLevelData = levelData;

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
