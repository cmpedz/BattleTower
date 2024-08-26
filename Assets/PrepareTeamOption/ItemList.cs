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

    [SerializeField] private List<GameObject> items = new List<GameObject>();   
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool addItem(GameObject item) {

        if (max_items != DEFAULT_ITEMS && max_items <= items.Count) return false;
        
        items.Add(item);

        item.transform.SetParent( gameObject.transform);

        return true;

    }

    public void removeItem(GameObject item) { 

        items.Remove(item);
    }
}
