using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class TowerController : MonoBehaviour, IObjectHurtController
{
    // Start is called before the first frame update

    [SerializeField] private Transform startPointSummon;

    [SerializeField] private Transform endPointSummon;

    [SerializeField] private Slider healthBar;


    // Update is called once per frame
    protected void Update()
    {

        Debug.Log(gameObject.ToString() + "current health value : " + healthBar.value + ", min health value : " + healthBar.minValue);

        if (healthBar.value <= healthBar.minValue) {

            eventsWhenTowerIsDefeated();

            selfDestroy();

        }
    }

    public Vector3 getPositionSummon()
    {
        float posY = Random.Range(endPointSummon.position.y, startPointSummon.position.y);

        return new Vector3(startPointSummon.position.x, posY, startPointSummon.position.z);
    }
    public abstract void eventsWhenTowerIsDefeated();

    public void defineHealthForHealthBar(float maxHealth) { 

            healthBar.maxValue = maxHealth;

            healthBar.minValue = 0;

            healthBar.value = maxHealth;
    }

    public void takeDam(float dam)
    {
        if (healthBar.value > 0)
        {
            healthBar.value -= dam;
        }
    }

    public void selfDestroy() {

        Destroy(gameObject);
    }


}
