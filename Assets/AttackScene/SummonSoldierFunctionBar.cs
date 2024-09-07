using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SummonSoldierFunctionBar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private ItemList content;

    [SerializeField] private Item itemForm;

    void Start()
    {
        foreach (PlayerSoliderScriptableObject soldierData in BattleDataStorage.Instance.SoldiersPlayerBrings) {

            GameObject soldier = Instantiate(itemForm.gameObject);

            soldier.GetComponent<Item>().ItemBrings = soldierData;

            content.addItem(soldier.GetComponent<Item>());

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
