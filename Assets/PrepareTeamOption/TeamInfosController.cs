using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TeamInfosController : MonoBehaviour
{

    [SerializeField] private ItemList solidersBringsContainer;

    [SerializeField] private ItemList solidersNotBringsContainer;

    [SerializeField] private Item itemForm;

    private static readonly string Soldier_Player_Brings_File = "SoldierPlayerBringsData.txt";

    private static readonly string Soldier_Player_Not_Brings_File = "SoldierPlayerNotBringsData.txt";


    // Start is called before the first frame update
    void Start()
    {
          putSolidersDataIntoTeamInfosDisplay();
    }

    private void putSolidersDataIntoTeamInfosDisplay() {

       Debug.Log("put data into team infors");

        getDataFromItemListIntoSpecifiedFile(Soldier_Player_Not_Brings_File, solidersNotBringsContainer, solidersBringsContainer);

        getDataFromItemListIntoSpecifiedFile(Soldier_Player_Brings_File, solidersBringsContainer, solidersNotBringsContainer);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        saveDataFromItemListIntoSpecifiedFile(Soldier_Player_Not_Brings_File, solidersNotBringsContainer);

        saveDataFromItemListIntoSpecifiedFile(Soldier_Player_Brings_File, solidersBringsContainer);
    }

    private void getDataFromItemListIntoSpecifiedFile(string fileName, ItemList itemListContaining, ItemList itemListCanMoveTo)
    {
        string dataTextForm = SaveSystem.getInstance().getDataFromSpecifedFile(fileName);

        ItemListData itemListFromFile = JsonUtility.FromJson<ItemListData>(dataTextForm);

        Debug.Log("check data received : " + itemListFromFile.itemBringsData);

        if (itemListFromFile == null || itemForm == null) return;

        foreach( ItemScriptableObject itemBringsData in itemListFromFile.itemBringsData) { 

            GameObject _item = Instantiate(itemForm.gameObject);

            _item.GetComponent<Item>().ItemBrings = itemBringsData;

            _item.GetComponent<MoveToNewListEventListener>().NewContainer = itemListCanMoveTo;

            itemListContaining.addItem(_item.GetComponent<Item>());

        }
    }

    private void saveDataFromItemListIntoSpecifiedFile(string fileName, ItemList itemList) { 

            ItemListData itemListData = new ItemListData();

            foreach (Item item in itemList.getItems()) {
                itemListData.itemBringsData.Add(item.ItemBrings);
            }
        
            string dataSave = JsonUtility.ToJson(itemListData);

            SaveSystem.getInstance().saveDataIntoSpecifiedFile(dataSave, fileName);
        
    }

    private class ItemListData {

        public List<ItemScriptableObject> itemBringsData;

        public ItemListData() {
            itemBringsData = new List<ItemScriptableObject>();
        }

    }
}
