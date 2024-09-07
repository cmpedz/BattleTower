using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveToNewListEventListener : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private ItemList currentContainer;

    [SerializeField] private ItemList newContainer;
    public ItemList NewContainer
    {
        get { return newContainer; }
        set { newContainer = value; }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        moveToNewContainer();
    }

    // Start is called before the first frame update
    void Start()
    {
        if(transform.parent != null)
        {
            bool isParentItemList = transform.parent.GetComponent<ItemList>() != null;

            if(isParentItemList)
            {
                currentContainer = transform.parent.GetComponent<ItemList>();
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void moveToNewContainer() {

        if (currentContainer == null || newContainer == null) return;


        if (newContainer.addItem(gameObject.GetComponent<Item>()))
        {
            currentContainer.removeItem(gameObject.GetComponent<Item>() );

            ItemList tmp = currentContainer;

            currentContainer = newContainer;

            newContainer = tmp;
        }

    }


}
