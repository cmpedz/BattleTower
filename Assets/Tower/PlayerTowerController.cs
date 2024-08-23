using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerTowerController : TowerController
{
    private float currentCoin = 0;
    public float CurrentCoin
    {
        get { return currentCoin; }
        set { currentCoin = value; }
    }

    [SerializeField] private float towerHealth;

    [SerializeField] private float MaxCoin;

    [SerializeField] private float coinPerSecond;


    [SerializeField] private TextMeshProUGUI coinDisplay;


    public override void eventsWhenTowerIsDefeated()
    {
        Debug.Log("player loses");
    }

    // Start is called before the first frame update
    void Start()
    {
        displayCoin();

        float timeIncreaseFund = 1;

        InvokeRepeating("expandFund",timeIncreaseFund, timeIncreaseFund);

        defineHealthForHealthBar(towerHealth);

    }

    // Update is called once per frame
    void Update()
    {
       base.Update();
    }


    public void expandFund()
    {

        this.currentCoin += coinPerSecond;

        if(currentCoin > MaxCoin)
        {
            currentCoin = MaxCoin;
        }

        displayCoin();
    }

    private void displayCoin()
    {
        if (coinDisplay != null)
        {
            string textDisplay = currentCoin + "/" + MaxCoin;

            coinDisplay.text = textDisplay;

        }
    }
}
