using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContainer : MonoBehaviour
{
    private ItemContainer() { }

    private static ItemContainer instance;

    // Start is called before the first frame update
    [SerializeField] private List<ItemScriptableObject> items;

    private static Dictionary<string, ItemScriptableObject> itemsMap = new Dictionary<string, ItemScriptableObject>();
    void Start()
    {

        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);

            foreach (ItemScriptableObject item in items)
            {
                if (!itemsMap.ContainsKey(item.name))
                {
                    Debug.Log("check item name : " + item.name);
                    itemsMap.Add(item.name, item);
                }

            }
        }
        else { 
            if(this != instance) { 
                Destroy(gameObject);
            }
        }

    }

    public static ItemScriptableObject getItemThroughName(string name) { 
        return itemsMap[name];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
