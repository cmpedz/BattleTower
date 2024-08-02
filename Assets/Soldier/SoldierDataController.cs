using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierDataController : MonoBehaviour
{
    [SerializeField] private SoldierScriptableObject soliderData;
    public SoldierScriptableObject SoliderData
    {
        get { return soliderData; }

        set { soliderData = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
