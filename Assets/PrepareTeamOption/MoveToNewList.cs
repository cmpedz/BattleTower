using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveToNewList : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private ItemList currentContainer;

    [SerializeField] private ItemList newContainer;
    public void OnPointerClick(PointerEventData eventData)
    {
        moveToNewContainer();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void moveToNewContainer() {

        if (currentContainer == null || newContainer == null) return;


        if (newContainer.addItem(gameObject))
        {
            currentContainer.removeItem(gameObject);

            ItemList tmp = currentContainer;

            currentContainer = newContainer;

            newContainer = tmp;
        }

    }


}
