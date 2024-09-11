using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDataFromTeamInforsIntoFile : MonoBehaviour
{

    [SerializeField] private ItemList solidersBringsContainer;

    [SerializeField] private ItemList solidersNotBringsContainer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDisable()
    {
        Debug.Log("save soldiers data players has into file");

        saveDataFromItemListIntoSpecifiedFile(SaveSystem.SOLDIERS_PLAYER_BRINGS_FILE, solidersBringsContainer);

        saveDataFromItemListIntoSpecifiedFile(SaveSystem.SOLDIERS_PLAYER_NOT_BRINGS_FILE, solidersNotBringsContainer);
    }

    private void saveDataFromItemListIntoSpecifiedFile(string fileName, ItemList itemList)
    {

        ItemListData itemListData = new ItemListData();

        foreach (Item item in itemList.getItems())
        {

            ItemScriptableObject itemBrings = item.ItemBrings;

            if (item != null)
            {
                itemListData.itemsBringsName.Add(itemBrings.name);
            }

        }

        string dataSave = JsonUtility.ToJson(itemListData);

        SaveSystem.getInstance().saveDataIntoSpecifiedFile(dataSave, fileName);

    }

   
}
