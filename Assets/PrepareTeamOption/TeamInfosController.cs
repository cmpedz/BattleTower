using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamInfosController : MonoBehaviour
{
    [SerializeField] private List<MoveToNewListEventListener> solidersNotBrings = new List<MoveToNewListEventListener>();

    [SerializeField] private ItemList solidersBringsContainer;

    [SerializeField] private ItemList solidersNotBringsContainer;

    // Start is called before the first frame update
    void Start()
    {
          putSolidersDataIntoTeamInfosDisplay();
    }

    private void putSolidersDataIntoTeamInfosDisplay() {

       Debug.Log("put data into team infors");

       foreach(MoveToNewListEventListener soldier in solidersNotBrings) { 

            GameObject _solider = Instantiate(soldier.gameObject);

            solidersNotBringsContainer.addItem(_solider.GetComponent<Item>());

            Debug.Log("adding solider data successfully");

            _solider.GetComponent<MoveToNewListEventListener>().NewContainer = solidersBringsContainer;

       }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        
    }
}
