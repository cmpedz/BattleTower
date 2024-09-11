
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Item : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Image itemBringsDisplay;

    [SerializeField] private ItemScriptableObject itemBrings;
    public ItemScriptableObject ItemBrings
    {
        set { itemBrings = value; }

        get { return itemBrings; }
    }
    void Start()
    {
        if (itemBringsDisplay != null && itemBrings != null) {

            itemBringsDisplay.sprite = itemBrings.sprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
