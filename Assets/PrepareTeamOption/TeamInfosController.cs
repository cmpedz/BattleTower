using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TeamInfosController : MonoBehaviour
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

        getDataFromItemListIntoSpecifiedFile(SaveSystem.SOLDIER_PLAYER_NOT_BRINGS_FILE, solidersNotBringsContainer, solidersBringsContainer);

        getDataFromItemListIntoSpecifiedFile(SaveSystem.SOLDIER_PLAYER_BRINGS_FILE, solidersBringsContainer, solidersNotBringsContainer);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        saveDataFromItemListIntoSpecifiedFile(SaveSystem.SOLDIER_PLAYER_NOT_BRINGS_FILE, solidersNotBringsContainer);

        saveDataFromItemListIntoSpecifiedFile(SaveSystem.SOLDIER_PLAYER_BRINGS_FILE, solidersBringsContainer);
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

    public class ItemListData {

        public List<ItemScriptableObject> itemBringsData;

        public ItemListData() {
            itemBringsData = new List<ItemScriptableObject>();
        }

    }
}
