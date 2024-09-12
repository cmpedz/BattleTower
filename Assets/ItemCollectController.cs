using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ItemCollectController
{
    public static void saveItemDataIntoSpecifiedFile(string fileName, string itemName, bool duplicationPermission) { 

            string itemsPlayerHas = SaveSystem.getInstance().getDataFromSpecifedFile(fileName);

            ItemListData currentItemsPlayerHas = JsonUtility.FromJson<ItemListData>(itemsPlayerHas);

            bool isItemDuplicated = currentItemsPlayerHas.itemsBringsName.Contains(itemName);

            if ( !duplicationPermission && isItemDuplicated) return;

            currentItemsPlayerHas.itemsBringsName.Add(itemName);

            string itemsPlayerHasToJson = JsonUtility.ToJson(currentItemsPlayerHas);

            SaveSystem.getInstance().saveDataIntoSpecifiedFile(itemsPlayerHasToJson, fileName);
            
    }

}
