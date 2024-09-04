using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamInfosController : MonoBehaviour
{
    [SerializeField] private List<MoveToNewList> solidersNotBrings = new List<MoveToNewList>();

    [SerializeField] private ItemList solidersBringsContainer;

    [SerializeField] private ItemList solidersNotBringsContainer;

    // Start is called before the first frame update
    void Start()
    {
          putSolidersDataIntoTeamInfosDisplay();
    }

    private void putSolidersDataIntoTeamInfosDisplay() {

       foreach(MoveToNewList soldier in solidersNotBrings) { 

            GameObject _solider = Instantiate(soldier.gameObject);

            _solider.SetActive(true);

            solidersNotBringsContainer.addItem(_solider);

            _solider.GetComponent<MoveToNewList>().NewContainer = solidersBringsContainer;

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
