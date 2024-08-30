using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelClickListener : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    [SerializeField] private LevelScriptableObject levelData;

    [SerializeField] private GameObject levelInforsMenu;

    [SerializeField] private TextMeshProUGUI levelName;

    public void OnPointerClick(PointerEventData eventData)
    {
        setUpCurrentLevelDisplay();

        setUpDataForLevel();
    }

    private void setUpCurrentLevelDisplay() {

        levelInforsMenu.SetActive(true);

        levelName.text = levelData.name;    
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
