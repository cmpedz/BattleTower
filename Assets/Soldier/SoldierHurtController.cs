using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierHurtController : MonoBehaviour
{
    // Start is called before the first frame update
    private SoldierAttributes soldierAttributes;

    public void takeDam(float dam)
    {
            GetComponent<Animator>().SetTrigger("HurtFlag");

            float healthLoss = this.soldierAttributes.getCurrentHealth() - dam;

            this.soldierAttributes.setCurrentHealth(healthLoss);

            selfDestroy();
    }


    void Start()
    {
        soldierAttributes = GetComponent<SoldierAttributes>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void selfDestroy()
    {
        if(soldierAttributes != null)
        {
            if( soldierAttributes.getCurrentHealth() <= 0)
            {
                
                Destroy(gameObject);
                
            }
        }
    }
}
