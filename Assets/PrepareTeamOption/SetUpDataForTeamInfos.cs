using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class SetUpDataForTeamInfos : MonoBehaviour
{

    [SerializeField] private ItemList solidersBringsContainer;

    [SerializeField] private ItemList solidersNotBringsContainer;

    [SerializeField] private Item itemForm;

    // Start is called before the first frame update
    void Start()
    {
          putSolidersDataIntoTeamInfosDisplay();
    }

    private void putSolidersDataIntoTeamInfosDisplay() {

       Debug.Log("put data into team infors");

        getDataFromSpecifiedFile(SaveSystem.SOLDIERS_PLAYER_NOT_BRINGS_FILE, solidersNotBringsContainer, solidersBringsContainer);

        getDataFromSpecifiedFile(SaveSystem.SOLDIERS_PLAYER_BRINGS_FILE, solidersBringsContainer, solidersNotBringsContainer);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void getDataFromSpecifiedFile(string fileName, ItemList itemListContaining, ItemList itemListCanMoveTo)
    {
        string dataTextForm = SaveSystem.getInstance().getDataFromSpecifedFile(fileName);

        ItemListData itemListFromFile = JsonUtility.FromJson<ItemListData>(dataTextForm);

        if (itemListFromFile == null || itemForm == null) return;

        foreach( string aItemBringsName in itemListFromFile.itemsBringsName) { 

            GameObject _item = Instantiate(itemForm.gameObject);

            _item.GetComponent<Item>().ItemBrings = ItemContainer.getItemThroughName(aItemBringsName);

            _item.GetComponent<MoveToNewListEventListener>().NewContainer = itemListCanMoveTo;

            itemListContaining.addItem(_item.GetComponent<Item>());

        }
    }


}
