using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : MonoBehaviour
{
    public static readonly int DEFAULT_ITEMS = -1;

    [SerializeField] private int max_items = DEFAULT_ITEMS;

    public int MAX_ITEMS {
        get { return max_items;  }
        set { max_items = value; }
    }

    [SerializeField] private List<Item> items = new List<Item>();   
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool addItem(Item item) {

        if (max_items != DEFAULT_ITEMS && max_items <= items.Count) return false;
        
        items.Add(item);

        item.gameObject.SetActive(true);

        item.transform.SetParent( gameObject.transform);

        item.transform.localScale = new Vector3(1, 1, 1);

        return true;

    }

    public List<Item> getItems() { return items;}

    public void removeItem(Item item) { 

        items.Remove(item);
    }
}
