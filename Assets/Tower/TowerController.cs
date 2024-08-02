using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float towerHealth;


    [SerializeField] private Transform startPointSummon;

    [SerializeField] private Transform endPointSummon;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 getPositionSummon()
    {
        float posY = Random.Range(endPointSummon.position.y, startPointSummon.position.y);

        return new Vector3(startPointSummon.position.x, posY, startPointSummon.position.z);
    }

    public void towerGetDam(float dam)
    {
        if (towerHealth > 0)
        {
            towerHealth -= dam;
        }
    }

    public abstract void eventWhenTowerDefeated();
}
