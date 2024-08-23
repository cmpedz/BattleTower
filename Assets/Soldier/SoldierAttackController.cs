using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAttackController : MonoBehaviour
{
    [SerializeField] private SoldierScriptableObject soldierData;

    private float speedAttack;
    public float SpeedAttack
    {
        get { return speedAttack; }
        set { speedAttack = value; }
    }

   
    private Animator animator;

    private bool isAttacking = false;

    public bool IsAttacking
    {
        get { return isAttacking; }

        set {  isAttacking = value; }
    }

 
    // Start is called before the first frame update
    void Start()
    {
        soldierData = GetComponent<SoldierDataController>().SoliderData;

        speedAttack = Time.time - GetComponent<SoldierAttributes>().getCurrentAttackSpeed();

        gameObject.layer =  getLayerIndexFromLayerMaskProvided(soldierData.type);

        animator = GetComponent<Animator>();


    }

    private int getLayerIndexFromLayerMaskProvided(LayerMask layerMask)
    {
        int layerMaskIntoInteger = layerMask.value;

        int maxLayer = 31;

        for(int i = 0; i <= maxLayer; i++)
        {
            int layerIndexIntoInteger = (int) Math.Pow(2, i);

            if(layerMaskIntoInteger == layerIndexIntoInteger)
            {
                return i;  
            }
        }

        return -1;

    }


    // Update is called once per frame
    void Update()
    {
       
       
        
    }

    public void attackEnemy(Collider2D enemy, AnimatorStateInfo animatorStateInfo)
    {

           
            
            if (animatorStateInfo.normalizedTime >= soldierData.timeCauseDam && isAttacking)
            {
                Debug.Log(enemy.ToString() + " getDamaged");

                enemy.GetComponent<IObjectHurtController>().takeDam(GetComponent<SoldierAttributes>().getCurrentDam());

                isAttacking = false;

                
            }

        
       
    }
}
