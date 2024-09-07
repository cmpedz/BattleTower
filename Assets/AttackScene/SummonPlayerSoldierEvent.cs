using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SummonPlayerSoldierEvent : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    [SerializeField] private GameObject soldierForm;

    [SerializeField] private PlayerTowerController playerTowerController;

    private Item itemContained;

    [SerializeField] private PlayerSoliderScriptableObject soldierDataStored;

    public PlayerTowerController PlayerTowerController
    {
        get { return playerTowerController; }
        set { playerTowerController = value; }
    }

    private bool isSummoned = false;

    [SerializeField] private GameObject wattingProcessBar;

    private Slider slider;


    public void OnPointerClick(PointerEventData eventData)
    {
        if(!isSummoned)
        {
            checkHavingEnoughMoney();
        }
        
    }

    void Awake() { 

        itemContained = GetComponent<Item>();

        soldierDataStored = (PlayerSoliderScriptableObject) itemContained.ItemBrings;
    }

    void Start()
    {
        slider = GetComponent<Slider>();

        slider.value = slider.minValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        waitForNextSummon();
    }

    private void waitForNextSummon()
    {
        if(isSummoned)
        {
            if(slider.value > slider.minValue)
            {
                float amountDecrease = Time.deltaTime / soldierDataStored.timeWattingForNextSummon;

                slider.value -= amountDecrease;
            }
            else
            {
                isSummoned = false;
            }

        }
    }

    private void checkHavingEnoughMoney()
    {
        if(playerTowerController == null || soldierDataStored == null) {  return; }

        bool isHavingEnoughMoney = playerTowerController.CurrentCoin >= soldierDataStored.cost;

        if (isHavingEnoughMoney)
        {
            playerTowerController.CurrentCoin -= soldierDataStored.cost;

            slider.value = slider.maxValue;

            isSummoned = true;

            summonSoldier();
        }
        
    }

    private void summonSoldier() {

        if (soldierForm != null) {

            GameObject soldier = Instantiate(soldierForm);

            Debug.Log("check soldier data : " + soldierDataStored);

            soldier.GetComponent<SoldierDataController>().SoliderData = soldierDataStored;

            soldier.SetActive(true);

            soldier.transform.position = playerTowerController.getPositionSummon();

            int orderInLayer = (int)(soldier.transform.position.y * -1000);

            soldier.GetComponent<SpriteRenderer>().sortingOrder = orderInLayer;


        }
    }
}
