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

    [SerializeField] private ItemList soldiersPlayerBrings;

    [SerializeField] private SummonPlayerSoldierEvent boxHasSummonPLayerListener;

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

        setUpDataForPlayer();

    }

    private void setUpDataForPlayer() {

        BattleDataStorage.Instance.SoldiersPlayerBrings.Clear();

        foreach (Item soldier in soldiersPlayerBrings.getItems())
        {

            PlayerSoliderScriptableObject soldierData = (PlayerSoliderScriptableObject) soldier.ItemBrings;

            if (soldierData != null)
            {
                BattleDataStorage.Instance.SoldiersPlayerBrings.Add(soldierData);
            }

        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
